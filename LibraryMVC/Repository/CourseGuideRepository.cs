using LibraryMVC4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryMVC4.Entity;
using System.Data.Objects.SqlClient;
using LibraryMVC4.Security;
using Ncu.Logging.Logger;
using System.Threading.Tasks;

namespace LibraryMVC4.Repository
{
    public class CourseGuideRepository : IRepository<guides>
    {
        public IEnumerable<guides> List(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<guides> GetAll()
        {
            throw new NotImplementedException();
           
        }

        public guides GetById(int? id)
        {
            using (var _ncuElrc = new LibEntities())
            {
                var getHeaderId = (from ech in _ncuElrc.elrc_cr_headers
                                   join ecg in _ncuElrc.elrc_cr_guides on ech.guide_id equals ecg.guide_id
                                   where ech.header_id == id
                                   select new guides
                                   {
                                       GuideBody = ecg.guide_body,
                                       HeaderBody = ech.header_body,
                                       TitleHeader = ech.header_title,
                                       HeaderId = ech.header_id

                                   }).FirstOrDefault();

                return getHeaderId;
            }
        }

        public IEnumerable<guides> List(string id)
        {
            using (var _ncuElrc = new LibEntities())
            {
                var getCourseGuides = (from c in _ncuElrc.GetCourseGuides(id)
                                       select new guides
                                       {
                                           GuideId = c.guide_id,
                                           CourseCode = c.course_code,
                                           CourseName = c.course_name,
                                           Enrollees = c.Enrollees,
                                           School = c.company_department_name,
                                           Display = c.display_id,
                                           LastName = c.last_name,
                                           CourseEndDate = c.course_end_date                                         

                                       }).ToList();

                return getCourseGuides;
            }
        }

        public IEnumerable<guides> GetSite(int id)
        {
            throw new NotImplementedException();
        }

        public guides GetById(int id)
        {
            throw new NotImplementedException();
        }

        public object Edit(guides entity)
        {
            var _libEntities = new LibEntities();
            bool result = false;
            try
            {
                elrc_cr_headers ech = _libEntities.elrc_cr_headers.FirstOrDefault(t => t.header_id == entity.HeaderId);

                ech.header_body = entity.HeaderBody;

                _libEntities.SaveChanges();                

            }
            catch (Exception)
            {
                throw;
            }

            finally
            {

                //we need to fix this code because the update could throw an exception. 

                elrc_cr_guides ecg = _libEntities.elrc_cr_guides.FirstOrDefault(t => t.guide_id == entity.GuideId);
                                
                ecg.display_id = entity.DisplayId;
                ecg.guide_body = entity.GuideBody;
                ecg.update_datetime = DateTime.Now;
                ecg.update_by = LibSecurity.UserId;

                _libEntities.SaveChanges();

                _libEntities.Connection.Close();
                _libEntities.Dispose();

                result = true;
            }

            return result;
        }

        public object Add(guides entity)
        {
            throw new NotImplementedException();
        }

        public object Delete(guides entity)
        {
            throw new NotImplementedException();
        }
    }
}