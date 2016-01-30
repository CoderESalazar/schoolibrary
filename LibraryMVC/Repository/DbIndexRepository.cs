using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryMVC4.Models;
using LibraryMVC4.Security;
using LibraryMVC4.Entity;
using Ncu.Logging.Logger;

namespace LibraryMVC4.Repository
{
    public class DbIndexRepository : IRepository<dbindex>
    {

        public IEnumerable<dbindex> List(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<dbindex> GetAll()
        {
            
            using (LibEntities _libEntity = new LibEntities())

            {
                var getMyDbIndex = (from db in _libEntity.db_index
                                    where db.display_id != false
                                    orderby db.db_title
                                    select new dbindex
                                    {
                                        dbTitle = db.db_title,
                                        dbCoverage = db.cover_id,
                                        dbKeyId = db.key_id,
                                        dbDisplay = db.display_id,
                                        dbType = db.identify_id, //subscription or freebie
                                        dbScholarly = db.scholary_id, //db is scholarly/peer reviewed
                                        dbFullText = db.full_text //db offers full-text content

                                    }).ToList();
                
                return getMyDbIndex;
             }

        }

        public dbindex GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<dbindex> List(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<dbindex> GetSite(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<dbindex> GetList<T>(string m, string p)
        {
            throw new NotImplementedException();
        }

        public dbindex GetById(int id)
        {
            using (LibEntities _libEntity = new LibEntities())
            {

                var getMyDb = (from db in _libEntity.db_index
                               where db.key_id == id
                               select new dbindex
                               {
                                   dbTitle = db.db_title,
                                   dbUrl = db.url_id,
                                   dbFullText = db.full_text,
                                   dbCoverage = db.cover_id,
                                   dbScholarly = db.scholary_id,
                                   dbType = db.identify_id, //subscription or freebie
                                   dbDesc = db.desc_resource,
                                   dbDisplay = db.display_id,
                                   dbKeyId = db.key_id

                               }).FirstOrDefault();

                return getMyDb;
            }
        }

        public object Edit(dbindex entity)
        {
            bool result = false;

            LibEntities _libEntities = new LibEntities();

            db_index db = _libEntities.db_index.FirstOrDefault(t => t.key_id == entity.dbKeyId);

            try
            {

                if (db != null)
                {
                    db.db_title = entity.dbTitle;
                    db.url_id = entity.dbUrl;
                    db.full_text = entity.dbFullText;
                    db.scholary_id = entity.dbScholarly;
                    db.cover_id = entity.dbCoverage;
                    db.identify_id = entity.dbType;
                    db.desc_resource = entity.dbDesc;
                    db.display_id = entity.dbDisplay;

                    _libEntities.SaveChanges();
                    result = true;
                }
            }
            catch 
            {
               result = false;
            }
            finally
            {
                _libEntities.Connection.Close();
            }

           return result;  
        }

        public object Add(dbindex entity)
        {
            LibEntities _libEntities = new LibEntities();

            bool result = false;

            try
            {
                var db_index = new db_index
                {
                    db_title = entity.dbTitle,
                    url_id = entity.dbUrl,
                    full_text = entity.dbFullText,
                    scholary_id = entity.dbScholarly,
                    cover_id = entity.dbCoverage,
                    identify_id = entity.dbType,
                    desc_resource = entity.dbDesc,
                    display_id = true

                };
                _libEntities.db_index.AddObject(db_index);
                _libEntities.SaveChanges();

                result = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _libEntities.Connection.Close();
            }
            return result;
        }

        public object Delete(dbindex entity)
        {
            using (var _libEntity = new LibEntities())
            {
                var deleteDb = _libEntity.db_index.FirstOrDefault(t => t.key_id == entity.dbKeyId);

                if (deleteDb == null)
                {
                    return false;
                }
                else
                {
                    _libEntity.DeleteObject(deleteDb);
                    _libEntity.SaveChanges();

                    return true;
                }       
            }
        }
    }
}