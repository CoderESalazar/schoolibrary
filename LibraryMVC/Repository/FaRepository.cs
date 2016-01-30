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
             throw new NotImplementedException();

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
            using (var _libEntity = new LibEntities())
            {
                var getFaSchool = (from fa in _libEntity.elrc_structure
                                   where fa.type_page == "fa"
                                   select new fa
                                   {
                                       school = fa.title_name,
                                       HighId = fa.high_id

                                   }).ToList();

                return getFaSchool;
            }
        }

        public object Edit(fa entity)
        {
            throw new NotImplementedException();
        }

        public object Add(fa entity)
        {
            LibEntities _libEntity = new LibEntities();
            bool result = false;

            //need remaining DB data fields to complete the update. 
            var getFields = _libEntity.db_index.FirstOrDefault(c => c.key_id == entity.dbKeyId);

            //next we need to check to see if DB reference already exists in find_article table
            var checkFindDbNoDupes = _libEntity.find_article.FirstOrDefault(c => c.dbProg == entity.HighId && c.dbTitle == getFields.db_title);
            
            if(checkFindDbNoDupes == null)
            {                
                try
                {
                    var addDb = new find_article
                    {
                        dbTitle = getFields.db_title,
                        dbDesc = getFields.desc_resource,
                        //dbUrl = getFields.url_id,
                        entered_datetime = DateTime.Now,
                        dbProg = entity.HighId,
                        dbIndexNum = entity.dbKeyId
                    };

                    _libEntity.find_article.AddObject(addDb);
                    _libEntity.SaveChanges();

                    result = true;
                }
                catch(Exception e)
                {
                    throw e;
                }
                finally 
                {
                    _libEntity.Connection.Close();
                }
            }
            else
            {
                result = false;                
            }

            return result;
        }

        public object Delete(fa entity)
        {
            using (var _libEntity = new LibEntities())
            {
                var deleteEvent = _libEntity.find_article.FirstOrDefault(c => c.db_num == entity.dbNum);

                if (deleteEvent == null)
                {
                    return false;
                }
                else
                {
                    _libEntity.DeleteObject(deleteEvent);
                    _libEntity.SaveChanges();

                    return true;
                }

            }
        }

        public IEnumerable<fa> GetSite(int id)
        {

            using (var _libEntity = new LibEntities())
            {
                var getFaPage = (from fa in _libEntity.find_article
                                 join db in _libEntity.db_index on fa.dbTitle equals db.db_title
                                 where fa.dbProg == id
                                 orderby db.db_title
                                 select new fa
                                 {
                                     dbTitle = fa.dbTitle,
                                     dbDescript = fa.dbDesc,
                                     dbUrl = db.url_id,
                                     dbNum = db.key_id

                                 }).ToList();

                return getFaPage;

            }

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
