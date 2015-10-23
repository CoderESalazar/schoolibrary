using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryMVC4.Models;
using LibraryMVC4.Entity;

namespace LibraryMVC4.Repository
{
    public class MmRepository: IRepository<structure>
    {

        private LibEntities _libEntity = new LibEntities();

        public IEnumerable<structure> List(string id)
        {
            throw new NotImplementedException();          

        }
        public structure GetById(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<structure> GetList()
        {
            throw new NotImplementedException();
        }

        public structure GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<structure> GetList(string m, string p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<structure> GetAll()
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

        public IEnumerable<structure> GetSite(int id)
        {
            var getTitleName = (from m in _libEntity.elrc_structure
                                where m.high_id == id
                                select new structure
                                {
                                    Title = m.title_name

                                }).ToList();

            return getTitleName;
        }

        public IEnumerable<structure> List(int id)
        {

            using (var _libEntity = new LibEntities())
            {
                var query = (from es in _libEntity.elrc_structure
                             where es.parent_id == id
                             orderby es.display_order, es.title_name
                             select new structure
                             {
                                 Title = es.title_name,
                                 HighId = es.high_id,
                                 ParentId = es.parent_id,
                                 PageType = es.type_page,
                                 LinkData = es.link_data

                             }).ToList();

                return query;

            }
        }
    }
}