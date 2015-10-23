using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryMVC4.Models;
using LibraryMVC4.Entity;

namespace LibraryMVC4.Repository
{
    public class GuideRepository : IGuides<guides>
    {
        public IEnumerable<guides> GetGuideTabs(int id)
        {
            using (var _libEntity = new LibEntities())
            {
                var guideTabList = (from ech in _libEntity.elrc_cr_headers
                                    join ecg in _libEntity.elrc_cr_guides on ech.guide_id equals ecg.guide_id
                                    into joined
                                    from ecg in joined.DefaultIfEmpty()
                                    where ech.guide_id == id
                                    select new guides
                                    {
                                        HeaderId = ech.header_id,
                                        TitleHeader = ech.header_title,
                                        GuideId = ech.guide_id,
                                        GuideBody = ecg.guide_body,
                                        DisplayOrder = ech.display_order,
                                        CGuideTitle = ecg.guide_title,

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
        public IEnumerable<guides> GetGuidesWOutBody(int id)
        {
            using (var _libEntity = new LibEntities())
            {
                var getGuidesWOutBody = (from ecg in _libEntity.elrc_cr_guides
                                         where ecg.guide_id == id
                                         select new guides
                                         {
                                             GuideBody = ecg.guide_body,
                                             GuideTitle = ecg.guide_title
                                         }).ToList();

                return getGuidesWOutBody;
            }
        }
         public IEnumerable<guides> GetSpecPage(int id)
        {

            using (var _libEntity = new LibEntities())
            {
                var specGuide = (from clv in _libEntity.concspec_list_v
                                 join ghi in _libEntity.guide_headers_info on clv.department_guide_main_id equals ghi.department_discipline_id
                                 join gr in _libEntity.guide_resources on ghi.guide_header_info_id equals gr.guide_header_info_id
                                 where clv.department_guide_main_id == id
                                 select new guides
                                 {
                                     GuideTitle = clv.guide_title,
                                     SpecHeaders = ghi.head_title,
                                     SpecResourceTitle = gr.resource_title,
                                     urlSpecResource = gr.url_resource,
                                     descSpecResource = gr.desc_resource
                                 }).ToList();

                return specGuide;
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
    }
}