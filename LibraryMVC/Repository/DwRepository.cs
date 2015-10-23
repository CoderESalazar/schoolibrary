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
    public class DwRepository : IRepository<structure>
    {
        public IEnumerable<structure> List(int id)
        {

            using (var _libEntity = new LibEntities())
            {
                var dwTest = (from e in _libEntity.elrc_dw_info
                          join e_s in _libEntity.elrc_structure on e.key_id equals e_s.link_data
                          where e_s.high_id == id
                          select new structure
                          {
                              Title = e_s.title_name,
                              Text = e.text_dw

                          }).ToList();


                return dwTest;
            }
        }
        public IEnumerable<structure> GetAll()
        {
            throw new NotImplementedException();
        }        

        public IEnumerable<structure> List(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<structure> GetSite(int id)
        {
            throw new NotImplementedException();
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