using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryMVC4.Models;
using LibraryMVC4.Entity;


namespace LibraryMVC4.Repository
{
    public class WlRepository : IRepository<wl>
    {

        public IEnumerable<wl> List(string id)
        {
            using (var _libEntity = new LibEntities())
            {

                var keyId = int.Parse(id);
                var wlTest = (from elrc_wl in _libEntity.elrc_wl_cat
                              join elrc_str in _libEntity.elrc_structure on elrc_wl.parent_id equals elrc_str.link_data
                              join elrc_w_l in _libEntity.elrc_wl_detail on elrc_wl.key_id equals elrc_w_l.parent_id
                              where elrc_str.high_id == keyId
                              orderby elrc_wl.cat_id ascending
                              select new wl
                                {
                                    Title = elrc_str.title_name,
                                    Category = elrc_wl.cat_id,
                                    Links = elrc_w_l.title_id,
                                    LinkDesc = elrc_w_l.desc_id,
                                    GetUrl = elrc_w_l.url_id

                                }).ToList();

                return wlTest;
            }

        }

        public wl GetById(int id)
        {
            throw new NotImplementedException();
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

        private IEnumerable<wl> GetCount(int id)
        {
            using (var _libEntity = new LibEntities())
            {
                var getLinkData = GetLinkData(id);

                var getCount = (from p in _libEntity.elrc_wl_cat
                                where p.parent_id == getLinkData.ToString()
                                select new wl
                                {
                                    LinkData = p.cat_id.Count().ToString()

                                }).ToList();

                return getCount;
            }

        }

        public IEnumerable<wl> GetList()
        {
            throw new NotImplementedException();
        }

        public wl GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<wl> GetList(string m, string p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<wl> GetAll()
        {
            throw new NotImplementedException();
        }

        public object Edit(wl entity)
        {
            throw new NotImplementedException();
        }

        public object Add(wl entity)
        {
            throw new NotImplementedException();
        }

        public object Delete(wl entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<wl> GetSite(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<wl> List(int id)
        {
            throw new NotImplementedException();
        }
    }
}
    
