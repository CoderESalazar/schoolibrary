using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryMVC4.Models;
using LibraryMVC4.Entity;
using System.Data.Objects.SqlClient;

namespace LibraryMVC4.Repository
{
    public class WlRepository : IRepository<wl>, IWl<wl>
    {
        public IEnumerable<wl> List(string id)
        {
            int keyId = Convert.ToInt32(id);

            using (var _libEntity = new LibEntities())

            {
                try
                {
                    var getLinkData = _libEntity.elrc_structure.FirstOrDefault(t => t.high_id == keyId);

                    int myLinkedData = Convert.ToInt32(getLinkData.link_data);

                    var getWlPage = (from cat in _libEntity.elrc_wl_cat
                                     join detail in _libEntity.elrc_wl_detail
                                     on cat.key_id equals detail.parent_id
                                     into joined
                                     from detail in joined.DefaultIfEmpty()
                                     where cat.parent_id == myLinkedData
                                     select new wl
                                     {
                                         PageTitle = getLinkData.title_name,
                                         Category = cat.cat_id,
                                         GetUrl = detail.url_id,
                                         LinkDesc = detail.desc_id,
                                         LinkId = detail.key_id != 0 ? detail.key_id : 0,
                                         CatId = cat.key_id != 0 ? cat.key_id : 0,
                                         Title = detail.title_id == null ? null : detail.title_id,
                                         Order = cat.order_id,
                                         DisplayOrder = detail.display_order

                                     }).ToList();

                    return getWlPage;

                }
                catch (Exception)
                {
                    throw;
                }


            }               

        }     


        public wl GetById(int id)
        {
            using (var _libEntity = new LibEntities())
            {
                try
                {
                    var getEditResource = (from wl_detail in _libEntity.elrc_wl_detail
                                           join wl_cat in _libEntity.elrc_wl_cat
                                           on wl_detail.parent_id equals wl_cat.key_id
                                           where wl_detail.key_id == id
                                           select new wl
                                           {
                                               Title = wl_detail.title_id,
                                               GetUrl = wl_detail.url_id,
                                               DisplayOrder = wl_detail.display_order,
                                               ParentId = wl_cat.parent_id,
                                               PrimaryKey = wl_detail.key_id,
                                               ResourceText = wl_detail.desc_id

                                           }).FirstOrDefault();

                    return getEditResource;
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }

        private wl GetLinkData(int id)
        {
            using (var _libEntity = new LibEntities())
            {
                var keyId = id;

                var LinkData = (from l in _libEntity.elrc_structure
                                where l.high_id == keyId
                                select new wl
                                {
                                    LinkData = l.link_data

                                }).FirstOrDefault();

                return LinkData;
            }

        }
        public IEnumerable<wl> GetList()
        {
            throw new NotImplementedException();
        }

        public wl GetById(int? id)
        {

            using (var _libEntity = new LibEntities())
            {
                try
                {
                    var editHeader = (from wl_cat in _libEntity.elrc_wl_cat
                                      where wl_cat.key_id == id
                                      select new wl
                                      {
                                          Category = wl_cat.cat_id,
                                          Order = wl_cat.order_id,
                                          ParentId = wl_cat.parent_id,
                                          PrimaryKey = wl_cat.key_id

                                      }).FirstOrDefault();

                    return editHeader;

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IEnumerable<wl> GetList(string m, string p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<wl> GetAll()
        {
            using (var _libEntity = new LibEntities())
            {
                var getWlPage = (from wl_info in _libEntity.elrc_wl_info
                                 orderby wl_info.title_wl
                                 select new wl
                                 {
                                     PrimaryKey = wl_info.key_id,
                                     PageTitle = wl_info.title_wl,                                                                                                                                      

                                 }).ToList();
                return getWlPage;
  
            }
        }

        public object EditPageTitle(wl entity)
        {
            bool result = false;

            using (var _libEntity = new LibEntities())
            {
                try
                {
                    elrc_wl_info wl_info = _libEntity.elrc_wl_info.FirstOrDefault(t => t.key_id == entity.PrimaryKey);
                    if (wl_info != null)
                    {
                        wl_info.title_wl = entity.Title;

                        _libEntity.SaveChanges();
                        
                    }

                    elrc_structure elrc_struct = _libEntity.elrc_structure.FirstOrDefault(t => t.high_id == entity.HighId);
                    if(elrc_struct != null)
                    {
                        elrc_struct.title_name = entity.Title;

                        _libEntity.SaveChanges();

                    }
                    result = true;

                }
                catch (Exception)
                {
                    throw;
                }

            }

            return result;
        }

        public object Edit(wl entity)
        {
            bool result = false;

            using (var _libEntity = new LibEntities())
            {
                try
                {
                    elrc_wl_detail wl_detail = _libEntity.elrc_wl_detail.FirstOrDefault(t => t.key_id == entity.PrimaryKey);

                    if (wl_detail != null)
                    {
                        wl_detail.title_id = entity.Title;
                        wl_detail.url_id = entity.GetUrl;
                        //wl_detail.display_order = entity.DisplayOrder;
                        wl_detail.desc_id = entity.ResourceText;

                        _libEntity.SaveChanges();
                        result = true;
                    }
                }
                catch (Exception)
                {
                    throw;

                }

            }
            return result;
        }

        public object EditHeader(wl entity)
        {
            bool result = false;

            using (var _libEntity = new LibEntities())
            {
                try
                {
                    elrc_wl_cat wl_cat = _libEntity.elrc_wl_cat.FirstOrDefault(t => t.key_id == entity.PrimaryKey);

                    if (wl_cat != null)
                    {
                        wl_cat.cat_id = entity.Category;
                        wl_cat.order_id = entity.Order;

                        _libEntity.SaveChanges();
                        result = true;
                    }

                }
                catch (Exception)
                {

                    throw;
                }
                return result;
            }
        }

        public object Add(wl entity)
        {
            bool result = false;

            using (var _libEntity = new LibEntities())
            {
                var wl_detail = new elrc_wl_detail
                {
                    parent_id = entity.CatId,
                    url_id = entity.GetUrl,
                    title_id = entity.Title,
                    desc_id = entity.ResourceText,
                    display_order = entity.DisplayOrder
                };

                _libEntity.elrc_wl_detail.AddObject(wl_detail);
                _libEntity.SaveChanges();
                result = true;
            }
            return result;
        }

        public object AddHeader(wl entity)
        {
            bool result = false;

            using (var _libEntity = new LibEntities())
            {
                var wl_cat = new elrc_wl_cat
                {
                    parent_id = entity.HighId,
                    cat_id = entity.Category,
                    order_id = entity.Order
                };

                _libEntity.elrc_wl_cat.AddObject(wl_cat);
                _libEntity.SaveChanges();
                result = true;
            }
            return result;
        }

        public object AddWlPage(wl entity)
        {
            bool result = false;

            using (var _libEntity = new LibEntities())
            {
                var wl_info = new elrc_wl_info
                {
                    title_wl = entity.Title
                };

                _libEntity.elrc_wl_info.AddObject(wl_info);
                _libEntity.SaveChanges();
                result = true;
            }

            return result;
        }

        public object Delete(wl entity)
        {
            bool result = false;
            using (var _libEntity = new LibEntities())
            {
                var wl_detail = _libEntity.elrc_wl_detail.FirstOrDefault(t => t.key_id == entity.PrimaryKey);

                if (wl_detail != null)
                {
                    _libEntity.DeleteObject(wl_detail);
                    _libEntity.SaveChanges();
                    return true;
                }

            }
            return result;
        }

        public object DeleteHeader(wl entity)
        {
            bool result = false;

            using (var _libEntity = new LibEntities())
            {
                var wl_cat = _libEntity.elrc_wl_cat.FirstOrDefault(t => t.key_id == entity.PrimaryKey);

                if (wl_cat != null)
                {
                    _libEntity.DeleteObject(wl_cat);
                    _libEntity.SaveChanges();
                    return true;
                }
            }
            return result;
        }

        public object DeleteWlPage(wl entity)
        {
            bool result = false;

            using (var _libEntity = new LibEntities())
            {
                var wl_info = _libEntity.elrc_wl_info.FirstOrDefault(t => t.key_id == entity.PrimaryKey);

                if (wl_info != null)
                {
                    _libEntity.DeleteObject(wl_info);
                    _libEntity.SaveChanges();
                    return true;
                }          
            }

            return result;
        }

        public IEnumerable<wl> GetSite(int id)
        {
            using (var _libEntity = new LibEntities())
            {

                var getCount2 = (from elrc_struct in _libEntity.elrc_structure
                                 join elrc_info in _libEntity.elrc_wl_info
                                 on elrc_struct.title_name equals elrc_info.title_wl
                                 join elrc_cat in _libEntity.elrc_wl_cat
                                 on elrc_info.key_id equals elrc_cat.parent_id
                                 where elrc_struct.high_id == id
                                 select new wl { }).ToList();

                return getCount2;

            }
        }

        public IEnumerable<wl> List(int id)
        {
            using (var _libEntity = new LibEntities())
            {
                try
                {
                    var getWlPage = (from wl_info in _libEntity.elrc_wl_info
                                     join wl_cat in _libEntity.elrc_wl_cat
                                     on wl_info.key_id equals wl_cat.parent_id
                                     into joined1
                                     from wl_cat in joined1.DefaultIfEmpty()
                                     join wl_detail in _libEntity.elrc_wl_detail
                                     on wl_cat.key_id equals wl_detail.parent_id
                                     into joined2
                                     from wl_detail in joined2.DefaultIfEmpty()
                                     where wl_info.key_id == id
                                     orderby wl_cat.order_id ascending
                                     select new wl
                                     {
                                         PageTitle = wl_info.title_wl,
                                         PrimaryKey = wl_info.key_id,
                                         Category = wl_cat.cat_id,
                                         DisplayOrder = wl_cat.order_id,
                                         Title = wl_detail.title_id == null ? null : wl_detail.title_id,
                                         Order = wl_detail.display_order,
                                         LinkId = wl_detail.key_id != 0 ? wl_detail.key_id : 0,
                                         CatId = wl_cat.key_id != 0 ? wl_cat.key_id : 0,
                                         GetUrl = wl_detail.url_id,
                                         LinkDesc = wl_detail.desc_id,
                                         
                                     }).ToList();

                    return getWlPage;

                }
                catch (Exception)
                {

                    throw;
                }


            }
        }

        public wl EditTitle(int id)
        {
            using (var _libEntity = new LibEntities())
            {
                try
                {
                    var editTitle = (from wl_info in _libEntity.elrc_wl_info
                                     where wl_info.key_id == id
                                     select new wl
                                     {                                         
                                         PrimaryKey = wl_info.key_id,
                                         Title = wl_info.title_wl
                                     }).FirstOrDefault();

                    return editTitle;

                }
                catch (Exception)
                {
                    throw;
                }

            }

        }

        public int GetCounts(int id)
        {
            using (var _libEntity = new LibEntities())
            {
                var getLinkData = _libEntity.elrc_structure.FirstOrDefault(t => t.high_id == id);

                int myLinkedData = Convert.ToInt32(getLinkData.link_data);

                int getCounts = (from cat in _libEntity.elrc_wl_cat
                                 where cat.parent_id == myLinkedData
                                 select cat).Count();

                return getCounts;

            }

        }
    }
}

