using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryMVC4.Models;
using LibraryMVC4.Entity;
using System.Data.SqlClient;
using System.Data.Entity;
using Ncu.Logging.Logger;

namespace LibraryMVC4.Repository
{
    public class DwRepository : IRepository<structure>
    {
        public IEnumerable<structure> List(int id)
        {

            using (var _libEntity = new LibEntities())
            {
                var getHigId = _libEntity.elrc_structure.FirstOrDefault(t => t.high_id == id);

                int linkData = Convert.ToInt32(getHigId.link_data);

                var dwTest = (from e in _libEntity.elrc_dw_info
                              join e_s in _libEntity.elrc_structure on e.key_id equals linkData
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

            using (var _libEntity = new LibEntities())
            {
                var dwAdminGrid = (from dw in _libEntity.elrc_dw_info
                                   orderby dw.title_dw  
                                   select new structure
                                   {
                                       PrimaryKey = dw.key_id,
                                       Title = dw.title_dw

                                   }).ToList();

                return dwAdminGrid;
            }

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
            using (var _libEntity = new LibEntities())
            {
                bool result = false;

                elrc_dw_info dw = _libEntity.elrc_dw_info.FirstOrDefault(t => t.key_id == entity.PrimaryKey);

                try
                {
                    dw.title_dw = entity.Title;
                    dw.text_dw = entity.Text;

                    _libEntity.SaveChanges();
                    result = true;      
                }
                catch (Exception e)
                {
                    throw e;
                    //ExceptionLogger.Log(ExceptionLogger.SeverityLevels.fatal, e, "Next action is to re-throw this exception object");
                    //result = false;
                }

                return result;
            }
        }

        public object Add(structure entity)
        {
            LibEntities _libEntity = new LibEntities();
            try
            {
                var dw_add = new elrc_dw_info
                {
                    title_dw = entity.Title,
                    text_dw = entity.Text,
                };
                _libEntity.elrc_dw_info.AddObject(dw_add);
                _libEntity.SaveChanges();

                return true;
            }
            catch( Exception e)
            {
                throw e;
            }
            finally
            {
                _libEntity.Connection.Close();
            }
         
        }

        public object Delete(structure entity)
        {
            using (var _libEntity = new LibEntities())
            {
                var deleteDw = _libEntity.elrc_dw_info.FirstOrDefault(t => t.key_id == entity.PrimaryKey);

                    if (deleteDw == null) 
                    {
                        return false;
                    }
                    else
                    {
                        _libEntity.DeleteObject(deleteDw);
                        _libEntity.SaveChanges();
                        
                        return true;
                    }
            }
        }
    
        public structure GetById(int? id)
        {
            throw new NotImplementedException();
        }
        public structure GetById(int id)
        {

            //string keyId = id.ToString();

            using (var _libEntity = new LibEntities())
            { 
                var editDw = (from dw in _libEntity.elrc_dw_info
                              where dw.key_id == id
                              select new structure
                              {                          
                                  Title = dw.title_dw,
                                  Text = dw.text_dw,
                                  PrimaryKey = dw.key_id
                          
                              }).FirstOrDefault();

                return editDw;
            }   

        }
    }
}