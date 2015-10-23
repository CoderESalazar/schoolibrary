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
    public class FaRepository : IRepository<fa>
    {

        public IEnumerable<fa> List(string id)
        {

            using (var _libEntity = new LibEntities())
            {
                
                var keyId = int.Parse(id);

                var faTest = (from fap in _libEntity.find_article_prog
                              join fa in _libEntity.find_article on fap.prog_num equals fa.dbProg
                              where fap.parent_id == keyId
                              orderby fa.dbTitle
                              select new fa
                              {
                                  dbTitle = fa.dbTitle,
                                  progTitle = fap.prog_title,
                                  dbDescript = fa.dbDesc,
                                  dbUrl = fa.dbUrl

                              }).ToList();

                return faTest;
            }

        }
        public fa GetById(int id)
        {
            throw new NotImplementedException(); 
        }

        public fa GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<fa> GetList(string m, string p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<fa> GetAll()
        {
            throw new NotImplementedException();
        }

        public object Edit(fa entity)
        {
            throw new NotImplementedException();
        }

        public object Add(fa entity)
        {
            throw new NotImplementedException();
        }

        public object Delete(fa entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<fa> GetSite(int id)
        {

            throw new NotImplementedException();
          
        }

        public IEnumerable<fa> List(int id)
        {
            using (var _libEntity = new LibEntities())
            {
                var getTitleName = (from f in _libEntity.elrc_structure
                                    where f.high_id == id
                                    select new fa
                                    {
                                        Title = f.title_name

                                    }).ToList();

                return getTitleName;
            }
        }
    }
}
