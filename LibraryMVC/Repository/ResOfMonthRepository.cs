using LibraryMVC4.Models;
using LibraryMVC4.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryMVC4.Repository
{
    public class ResOfMonthRepository : IRepository<res>
    {
        public object Add(res entity)
        {
            bool result = false;
            using (var _libEntity = new LibEntities())
            {
                var resourceAdd = new resources_tb
                {
                    resource_title = entity.ResourceTitle,
                    resource_content = entity.ResourceText,
                    display_resource_id = false,
                    date_time = DateTime.Now                    
                };

                _libEntity.resources_tb.AddObject(resourceAdd);
                _libEntity.SaveChanges();

            }

            return result;
        }

        public object Delete(res entity)
        {
            bool result = false;

            using (var _libEntity = new LibEntities())
            {
                var deleteResource = _libEntity.resources_tb.FirstOrDefault(t => t.entry_id == entity.EntryId);
                _libEntity.DeleteObject(deleteResource);
                _libEntity.SaveChanges();
                result = true;

            }
            return result;
        }

        public object Edit(res entity)
        {
            bool result = false;
            using (var _libEntity = new LibEntities())
            {
                resources_tb rtb = _libEntity.resources_tb.FirstOrDefault(t => t.entry_id == entity.EntryId);

                rtb.resource_title = entity.ResourceTitle;
                rtb.resource_content = entity.ResourceText;
                rtb.display_resource_id = entity.Display;
                rtb.date_time = DateTime.Now;

                _libEntity.SaveChanges();
                result = true; 

            }
            return result;
        }

        public IEnumerable<res> GetAll()
        {
            using (LibEntities _libEntity = new LibEntities())
            {
                var getRes = (from res_tb in _libEntity.resources_tb
                              orderby res_tb.date_time descending
                              select new res
                              {
                                  EntryId = res_tb.entry_id,
                                  ResourceTitle = res_tb.resource_title,
                                  Date = res_tb.date_time,
                                  Display = res_tb.display_resource_id

                              }).ToList();

                return getRes;
            }
        }

        public res GetById(int id)
        {
            using (LibEntities _libEntity = new LibEntities())
            {
                var editResource = (from res_tb in _libEntity.resources_tb
                                    where res_tb.entry_id == id
                                    select new res
                                    {
                                        EntryId = res_tb.entry_id,
                                        ResourceTitle = res_tb.resource_title,
                                        ResourceText = res_tb.resource_content,
                                        Display = res_tb.display_resource_id

                                    }).FirstOrDefault();

                return editResource;
            }
        }
        public res GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<res> GetSite(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<res> List(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<res> List(int id)
        {
            throw new NotImplementedException();
        }
    }
}