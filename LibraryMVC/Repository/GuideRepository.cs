using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryMVC4.Models;
using LibraryMVC4.Entity;
using LibraryMVC4.Security;

namespace LibraryMVC4.Repository
{
    public class GuideRepository : IGuides<guides>
    {
        public IEnumerable<guides> GetGuideTabs(int id)
        {
            using (var _libEntity = new LibEntities())
            {
                //going to modify this query so that it's a left join. Also, need to add some null statements.
                //this method is being called from two different controllers. 
                //saving original query, 1/7/2016.

                var guideTabList = (from ecg in _libEntity.elrc_cr_guides
                                    join ech in _libEntity.elrc_cr_headers on ecg.guide_id equals ech.guide_id
                                    into joined
                                    from ech in joined.DefaultIfEmpty()
                                    where ecg.guide_id == id
                                    select new guides
                                    {
                                        HeaderId = ech.header_id == 0 ? 0 : ech.header_id,
                                        TitleHeader = ech.header_title == null ? null : ech.header_title,
                                        GuideId = ecg.guide_id,
                                        GuideBody = ecg.guide_body,
                                        DisplayOrder = ech.display_order == null ? 0 : ech.display_order,
                                        CGuideTitle = ecg.course_code + " - " + ecg.guide_title,
                                        HeaderBody = ech.header_body,
                                        DisplayId = ecg.display_id,
                                        CourseCode = ecg.course_code

                                    }).ToList();                     
                 
                return guideTabList;
            }
        }
        public IEnumerable<guides> GetSpecTitleList()
        {

            using (var _libEntity = new LibEntities())
            {
                var getSpectTitleList = (from c in _libEntity.concspec_list_v
                                         where c.display_id == true
                                         orderby c.guide_title
                                         select new guides
                                         {
                                             GuideTitle = c.guide_title,
                                             DeptId = c.department_discipline_id,
                                             DeptGuideId = c.department_guide_main_id,
                                             DisplayId = c.display_id

                                         }).ToList();

                return getSpectTitleList;

            }

        }
        public IEnumerable<guides> GetCourseGuides()
        {

            using (var _libEntity = new LibEntities())
            {
                var getCourseGuides = (from cg in _libEntity.course_guides_v
                                       orderby cg.course_code
                                       select new guides
                                        {
                                            CourseCode = cg.course_code,
                                            GuidesId = cg.guide_id

                                        }).ToList();

                return getCourseGuides;
            }
        }

        public IEnumerable<guides> GetGuidesWithBody(int id)
        {
            using (var _libEntity = new LibEntities())
            {
                var getGuidesWBody = (from ech in _libEntity.elrc_cr_headers
                                      join ecg in _libEntity.elrc_cr_guides on ech.guide_id equals ecg.guide_id
                                      into joined
                                      from ecg in joined.DefaultIfEmpty()
                                      where ech.header_id == id
                                      select new guides
                                      {
                                          HeaderId = ech.header_id,
                                          TitleHeader = ech.header_title,
                                          GuideBody = ecg.guide_body,
                                          HeaderBody = ech.header_body

                                      }).ToList();

                return getGuidesWBody;
            }
        }
       
         public IEnumerable<guides> GetSpecPage(int? id)
        {
             //need to rewrite this query as a left join because there are null in the outer tables. 
            using (var _libEntity = new LibEntities())
            {       
                var specPage = (from clv in _libEntity.concspec_list_v
                                join ghi in _libEntity.guide_headers_info on clv.department_guide_main_id equals ghi.department_discipline_id
                                into joined1
                                from ghi in joined1.DefaultIfEmpty()
                                join gr in _libEntity.guide_resources on ghi.guide_header_info_id equals gr.guide_header_info_id
                                into joined2
                                from gr in joined2.DefaultIfEmpty()
                                join db in _libEntity.db_index on gr.key_id equals db.key_id
                                into joined3
                                from db in joined3.DefaultIfEmpty()
                                where clv.department_guide_main_id == id
                                orderby ghi.display_order, ghi.head_title
                                select new guides
                                {
                                    GuideTitle = clv.guide_title,
                                    SpecHeaders = ghi.head_title == null ? null : ghi.head_title,
                                    SpecResourceTitle = gr.key_id == null ? gr.resource_title : db.db_title,
                                    urlSpecResource = gr.key_id == null ? gr.url_resource : db.url_id,
                                    HeaderId = ghi.guide_header_info_id == 0 ? 0 : ghi.guide_header_info_id,
                                    descSpecResource = gr.key_id == null ? gr.desc_resource : db.desc_resource,
                                    //GuideResourceId = gr.guide_resource_id == null ? 0 : gr.guide_resource_id,
                                    GuideResourceId = gr.guide_resource_id != 0 ? gr.guide_resource_id : 0,
                                    GuideId = gr.key_id,
                                    DeptDiscpId = gr.department_discipline_id

                                }).ToList();

                    return specPage;

             }
          
        }
         public int GetCount(int id)
         {
             using (var _libEntity = new LibEntities())
             {
                 var getCount = (from clv in _libEntity.concspec_list_v
                                 join ghi in _libEntity.guide_headers_info on clv.department_guide_main_id
                                 equals ghi.department_discipline_id
                                 where clv.department_guide_main_id == id
                                 select ghi).Count();

                 return getCount;
             }           
             
         }
         public IEnumerable<guides> GetSpecGuides()
         {             
             using (var _libEntity = new LibEntities())
             {
                 var getSpecGuides = (from g in _libEntity.department_disciplines
                                      join c in _libEntity.concspec_list_v on g.department_id equals c.department_id
                                      where c.gen_ed == false
                                      select new guides
                                      {
                                          DeptSpecId = g.department_id,
                                          School = g.discipline_title,
                                          GuideTitle = c.guide_title,
                                          DeptGuideMainId = c.department_guide_main_id,
                                          DeptDiscpId = c.department_discipline_id,
                                          DisplayId = c.display_id

                                      }).ToList();

                 return getSpecGuides;
             }
         }
         public IEnumerable<guides> GetSpecListDropDown(int id)
         {
            
             using (var _libEntity = new LibEntities())
             {

                 var getSpecListDropDown = (from c in _libEntity.GetSpecs(id)
                                            select new guides
                                            {
                                               SectionName = c.section_name 
                                                                                            
                                            }).ToList();

                 return getSpecListDropDown;      
             
            }
         }
         public object AddSpec(guides entity)
         {
             LibEntities _libEntity = new LibEntities();
             bool result = false;

             try
             {
                 var addSpec = new department_guides_main
                 {
                     department_discipline_id = (int)entity.DeptDiscpId,
                     guide_title = entity.SectionName,
                     gen_ed = false,
                     entered_datetime = DateTime.Now,
                     entered_by = LibSecurity.UserId
                 };

                 _libEntity.department_guides_main.AddObject(addSpec);
                 _libEntity.SaveChanges();
                 result = true;
             }
             catch(Exception e)
             {
                 throw new ApplicationException("Add Failed!", e);
             }
             finally
             {
                 _libEntity.Connection.Close();
             }
             return result;
         }

         public object AddHeader(guides entity)
         {
             LibEntities _libEntity = new LibEntities();
             bool result = false;

             try
             {
                 var addHeader = new guide_headers_info
                 {
                     department_discipline_id = (int)entity.DeptGuideId,
                     head_title = entity.SectionName,
                     display_order = entity.DisplayOrder,
                     entered_datetime = DateTime.Now
                 };

                 _libEntity.guide_headers_info.AddObject(addHeader);
                 _libEntity.SaveChanges();
                 result = true;
             }
             catch(Exception e)
             {
                 throw new ApplicationException("Add Failed!", e);
             }
             finally
             {
                 _libEntity.Connection.Close();
                 _libEntity.Dispose();
             }

             return result;
         }
        public object AddCourseGuide(string course)
        {
            bool result = false;
            var _libEntity = new LibEntities();

            try
            {
                var getCourseName = _libEntity.GetCourseName(course).FirstOrDefault();

                var addNewGuide = new elrc_cr_guides
                {
                    course_code = course,
                    guide_title = getCourseName.ToString(),
                    update_datetime = DateTime.Now,
                    update_by = LibSecurity.UserId
                };

                _libEntity.elrc_cr_guides.AddObject(addNewGuide);
                _libEntity.SaveChanges();
                result = true;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _libEntity.Connection.Close();
                _libEntity.Dispose();
            }

            return result;
        }

        public object AddTab(string id)
         {
             bool result = false;
             using (var _libEntity = new LibEntities())
             {
                 var addTab = new elrc_cr_tabs
                 {
                     tab_name = id
                 };

                 _libEntity.elrc_cr_tabs.AddObject(addTab);
                 _libEntity.SaveChanges();
                 result = true;
             }
             return result;
         }


         public object AddNewTab(int guideId, int tabId)
         {
             bool result = false;         

             using (var _libEntity = new LibEntities())
             {
                  var getTabHeader = _libEntity.elrc_cr_tabs.FirstOrDefault(t => t.tab_id == tabId);

                  var addNewTab = new elrc_cr_headers
                  {
                      header_title = getTabHeader.tab_name,
                      guide_id = guideId,
                      display_order = tabId,
                      //header_body = "Please enter text into box."

                  };

                  _libEntity.elrc_cr_headers.AddObject(addNewTab);
                  _libEntity.SaveChanges();
                  result = true;
             }

             return result;
         }

         public object AddResource(guides entity)
         {
             LibEntities _libEntity = new LibEntities();
             bool result = false;

             int? id = entity.dbKeyId;

             if (id != 0)
             {
                 var getDbInfo = _libEntity.db_index.FirstOrDefault(t => t.key_id == entity.dbKeyId);

                 try
                 {
                     var addResource = new guide_resources
                     {
                         guide_header_info_id = entity.HeaderId,
                         key_id = entity.dbKeyId,
                         department_discipline_id = entity.DeptDiscpId,
                         resource_title = getDbInfo.db_title,
                         url_resource = getDbInfo.url_id,
                         entered_datetime = DateTime.Now
                     };
                     _libEntity.guide_resources.AddObject(addResource);
                     _libEntity.SaveChanges();
                     result = true;
                 }
                 catch (Exception)
                 {
                     throw;
                 }
                 finally
                 {
                     _libEntity.Connection.Close();
                 }

             } else
             {
                 try
                 {
                     var addResource = new guide_resources
                     {
                         guide_header_info_id = entity.HeaderId,
                         department_discipline_id = entity.DeptDiscpId,
                         resource_title = entity.ResourceTitle,
                         desc_resource = entity.ResourceDesc,
                         url_resource = entity.ResourceUrl,
                         entered_datetime = DateTime.Now
                     };
                     _libEntity.guide_resources.AddObject(addResource);
                     _libEntity.SaveChanges();
                     result = true;
                 }
                 catch (Exception)
                 {
                     throw;
                 }
                 finally
                 {
                     _libEntity.Connection.Close();
                    _libEntity.Dispose();
                 }
             }
             return result;
         }
         public guides HeaderPage(int id)
         {
             using (var _libEntity = new LibEntities())
             {
                 var getSpecTitle = (from t in _libEntity.department_guides_main
                                     where t.department_guide_main_id == id
                                     select new guides
                                     {
                                         TitleHeader = t.guide_title

                                     }).FirstOrDefault();

                 return getSpecTitle;
             }
         }
         public IEnumerable<guides> GetHeaderDropDown()
         {
             using (var _libEntity = new LibEntities())
             {
                 var getHeaderDropDown = (from n in _libEntity.master_header
                                          select new guides
                                          {
                                              SectionName = n.header_title

                                          }).ToList();

                 return getHeaderDropDown;
             }
         }
         public guides ResourcePage(int id)
         {
             using (var _libEntity = new LibEntities())
             {
                 var resourcePage = (from n in _libEntity.guide_headers_info
                                     where n.guide_header_info_id == id
                                     select new guides
                                     {
                                         TitleHeader = n.head_title,
                                         DeptDiscpId = n.department_discipline_id
                                     }).FirstOrDefault();

                 return resourcePage;
             }
         }

         public guides EditResourcePage(int id)
         {
            using (var _libEntity = new LibEntities())
            {
                var editResource = (from n in _libEntity.GetGuideResource(id)
                                    select new guides
                                    {
                                        ResourceTitle = n.title, 
                                        ResourceDesc = n.desc_resource,
                                        ResourceUrl = n.url,
                                        GuideResourceId = n.guide_resource_id,
                                        DeptDiscpId = n.department_discipline_id

                                    }).FirstOrDefault();

                return editResource;
            }
         }

         public object EditResource(guides entity)
         {
            using (var _libEntities = new LibEntities())
            {
                bool result = false;

                guide_resources gr = _libEntities.guide_resources.FirstOrDefault(t => t.guide_resource_id == entity.GuideResourceId);

                try
                {
                    gr.resource_title = entity.ResourceTitle;
                    gr.url_resource = entity.ResourceUrl;
                    gr.desc_resource = entity.ResourceDesc;
                    gr.entered_datetime = DateTime.Now;

                    _libEntities.SaveChanges();
                    result = true;
                }
                catch (Exception e)
                {                    
                    throw new ApplicationException("Update failed!", e);
                }
                finally
                {
                    _libEntities.Connection.Close();
                }
                return result;
            }
         }
        public object UpdateHeader(guides entity)
         {
             using (var _libEntities = new LibEntities())
             {
                 bool result = false;

                 int id = Convert.ToInt32(entity.HeaderId);

                 guide_headers_info ghi = _libEntities.guide_headers_info.FirstOrDefault(c => c.guide_header_info_id == id);

                 try
                 {
                     ghi.head_title = entity.TitleHeader;
                     ghi.display_order = entity.DisplayOrder;

                     _libEntities.SaveChanges();
                     result = true;
                 }
                 catch (Exception e)
                 {                     
                     throw new ApplicationException("Update Failed!", e);
                 }
                 finally
                 {
                     _libEntities.Connection.Close();
                 }
                 return result;
             }
         }
        public object UpdateDisplay(bool boolId, int id)
        {
            using (var _libEntities = new LibEntities())
            {
                bool result = false;

                department_guides_main dgm = _libEntities.department_guides_main.FirstOrDefault(t => t.department_guide_main_id == id);

                try
                {
                    if (boolId)
                    {
                        dgm.display_id = false;
                    }
                    else { 
                        dgm.display_id = true;
                    }
                    _libEntities.SaveChanges();
                    result = true;
                }
                catch (Exception e)
                {
                    
                    throw new ApplicationException("Update Failed!", e);
                }
                finally
                {
                    _libEntities.Connection.Close();
                }
                return result;
            }
        }
         public object DeleteResource(int id)
         {
             using (var _libEntities = new LibEntities())
             {
                 var deleteResource = _libEntities.guide_resources.FirstOrDefault(t => t.guide_resource_id == id);
                 
                 if (deleteResource == null)
                 {
                     return false;
                 }
                 else
                 {
                     _libEntities.DeleteObject(deleteResource);
                     _libEntities.SaveChanges();

                     return true;
                 }
             }
         }
         public guides GetHeader(int id)
         {
            using (var _libEntities = new LibEntities())
            {
                var getHeader = (from ghi in _libEntities.guide_headers_info
                                 where ghi.guide_header_info_id == id
                                 select new guides
                                 {
                                     TitleHeader = ghi.head_title,
                                     HeaderId = ghi.guide_header_info_id,
                                     DeptDiscpId = ghi.department_discipline_id,
                                     DisplayOrder = ghi.display_order

                                 }).FirstOrDefault();

                return getHeader;
            }
         }

         public object DeleteHeader(int id)
         {
             using (var _libEntities = new LibEntities())
             {

                 bool result = false;

                 var checkForOrphans = _libEntities.guide_resources.FirstOrDefault(t => t.guide_header_info_id == id);

                 if (checkForOrphans == null)
                 {
                     var deleteHeader = _libEntities.guide_headers_info.FirstOrDefault(t => t.guide_header_info_id == id);
                     _libEntities.DeleteObject(deleteHeader);
                     _libEntities.SaveChanges();

                     return true;
                 }

                 return result;
             }
         }

         public object DeleteTab(int guideId, int headerId)
         {             

             if (headerId != 0)
             {                 
                 using (var _libEntity = new LibEntities())
                 {
                    

                     var deleteHeaderId = _libEntity.elrc_cr_headers.FirstOrDefault(t => t.header_id == headerId);

                     _libEntity.DeleteObject(deleteHeaderId);
                     _libEntity.SaveChanges();

                     return true;                     

                 }

             } else
             {
                 using (var _libEntity = new LibEntities())
                 {
                 
                     var deleteGuideId = _libEntity.elrc_cr_guides.Join(_libEntity.elrc_cr_headers, guidId => guidId.guide_id, headId => headId.header_id, (guidId, headId) => new { Guides = guidId, Headers = headId }).Where(GuidesAndHeaders => GuidesAndHeaders.Guides.guide_id == guideId);

                     _libEntity.DeleteObject(deleteGuideId);
                     _libEntity.SaveChanges();

                     return true;
                 }
          
                 
             }

             

         }

         public guides GetGuideBody(int guideId, int headerId)
         {
             if (headerId != 0)
             {              
                 using (var _libEntity = new LibEntities())
                    {

                     try 
                     {	        
		                        var getGuideBody = (from ecg in _libEntity.elrc_cr_guides
                                                    join ech in _libEntity.elrc_cr_headers on ecg.guide_id equals ech.guide_id
                                                    into joined
                                                    from ech in joined.DefaultIfEmpty()
                                                    where ecg.guide_id == guideId && ech.header_id == headerId
                                                    select new guides
                                                    {
                                                        HeaderId = ech.header_id == 0 ? 0 : ech.header_id,
                                                        TitleHeader = ech.header_title == null ? null : ech.header_title,
                                                        GuideId = ech.guide_id,
                                                        GuideBody = ecg.guide_body,
                                                        DisplayOrder = ech.display_order == null ? 0 : ech.display_order,
                                                        CGuideTitle = ecg.guide_title,
                                                        HeaderBody = ech.header_body,
                                                        CourseCode = ecg.course_code

                                                    }).FirstOrDefault(); 

                                         return getGuideBody;
	                        }
	                catch (Exception)
	                {
		
		                throw;
	                }
                 

                    }

             }  else
             {

                  using (var _libEntity = new LibEntities())
                    {

                         try
                         {
                             var getEmptyHeaderBody = (from ecg in _libEntity.elrc_cr_guides
                                                       where ecg.guide_id == guideId
                                                       select new guides
                                                       {
                                                           GuideBody = ecg.guide_body

                                                       }).FirstOrDefault();

                             return getEmptyHeaderBody;



                         }
                         catch (Exception)
                         {
                     
                             throw;
                         }

                  }

             }

         }    
     
        public IEnumerable<guides> GetTabs()
         {

             using (var _libEntities = new LibEntities())
             {
                 var getTabs = (from ect in _libEntities.elrc_cr_tabs
                                 select new guides
                                 {
                                    TabId = ect.tab_id,
                                    TabName = ect.tab_name                  

                                 }).ToList();

                return getTabs;
             }

         }       
    }
}