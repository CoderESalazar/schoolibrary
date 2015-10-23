using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryMVC4.Models;
using LibraryMVC4.Entity;
using System.Data.SqlClient;
using System.Data.Entity;

namespace LibraryMVC4.Repository
{
    public class SiteMapRepository : IRepository<structure>
    {
        public IEnumerable<structure> List(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<structure> GetAll()
        {

            using (var _libEntity = new LibEntities())
            {
                var nodes = (from c in _libEntity.elrc_structure
                             orderby c.display_order, c.title_name
                             select new structure
                             {
                                 HighId = c.high_id,
                                 ParentId = c.parent_id,
                                 PageTitle = c.title_name,
                                 PageType = c.type_page,
                                 LinkData = c.link_data

                             }).ToList();

                return nodes;
            }
        }

        public IEnumerable<structure> List(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<structure> GetSite(int id)
        {
            using (var _libEntity = new LibEntities())
            {
                var breadCrumb = (from es in _libEntity.GetBreadCrumbs(id)
                                  select new structure
                                  {
                                      HighId = (int)es.high_id,
                                      PageTitle = es.title_name,
                                      ParentId = es.parent_id,
                                      LinkData = es.link_data,
                                      DisplayOrder = es.display_order,
                                      PageType = es.type_page

                                  }).ToList();


                return breadCrumb;
            }
        }

        public IEnumerable<structure> GetList(string m, string p)
        {
            throw new NotImplementedException();
        }     

        public object Edit(structure entity)
        {
            throw new NotImplementedException();
        }

        public object Add(structure entity)
        {
            throw new NotImplementedException();
        }

        public object Delete(structure entity)
        {
            throw new NotImplementedException();
        }

        public structure GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public structure GetById(int id)
        {
            throw new NotImplementedException();
        }
    }

}