using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryMVC4.Models;
using LibraryMVC4.Entity;
using System.Data.Objects.SqlClient;
using LibraryMVC4.Security;

namespace LibraryMVC4.Repository
{
    public class ScheduleRepository: IRepository<schedule>, ISchedule<schedule>
    {
        //private LibEntities _libEntity = new LibEntities();


        public IEnumerable<schedule> GetAll()
        {
            using (var _libEntity = new LibEntities())
            {

                var getSchedule = (from lc in _libEntity.lib_calendar
                                   join lr in _libEntity.lib_registerees on new { event_id = lc.event_id } equals new { event_id = (int)lr.event_id } into lr_join
                                   from lr in lr_join.DefaultIfEmpty()
                                   where
                                     lc.event_date > SqlFunctions.CurrentTimestamp()
                                   group new { lr, lc } by new
                                   {
                                       lr.event_id,
                                       Column1 = lc.event_id,
                                       lc.lib_event,
                                       lc.event_date,
                                       lc.event_details,
                                       lc.attend_details
                                   } into g
                                   where g.Count(p => p.lr.event_id != null) < 24
                                   orderby
                                     g.Key.event_date
                                   select new schedule
                                   {
                                       lrEventId = g.Count(p => p.lr.event_id != null),
                                       lcEventId = (int)g.Key.Column1,
                                       eventDate = g.Key.event_date,
                                       eventDetails = g.Key.event_details,
                                       attendDetails = g.Key.attend_details
                                   }).ToList();

                return getSchedule;
            }
        }

        public schedule GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<schedule> List(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<schedule> GetList(string m, string p)
        {
            throw new NotImplementedException();
        }

        public schedule GetById(int id)
        {
            using (var _libEntity = new LibEntities())
            {
                var checkRegistration = _libEntity.lib_registerees.FirstOrDefault(c => c.event_id == id && c.user_id == LibSecurity.UserId);

                //if checkRegistration comes back null then student has NOT registered for the event. 
                
                if (checkRegistration == null)
                {
                    var getEventInfo = (from lc in _libEntity.lib_calendar
                                        where lc.event_id == id
                                        select new schedule
                                        {
                                            workShopTitle = lc.lib_home,
                                            eventDate = lc.event_date

                                        }).FirstOrDefault();

                    RegisterUser(id);                    
                    return getEventInfo;
                    
                }
                return null;

            }
            //if the checkRegistration comes back not null then that means they are already registered for the event. 

        }
        private static void RegisterUser(int id)
        {
            using (var _libEntity = new LibEntities())
            {         
                UserRepository myUser = new UserRepository();
                var t = myUser.GetUserInfo();

                var workshop = new lib_registerees
                {
                    first_name = t.PatronFirstName,
                    last_name = t.PatronLastName,
                    date_time = DateTime.Now,
                    email_address = t.PatronEmail,
                    user_id = LibSecurity.UserId,
                    event_id = id
                };
                _libEntity.lib_registerees.AddObject(workshop);
                _libEntity.SaveChanges();
            }

        }
        public object Edit(schedule entity)
        {
            throw new NotImplementedException();
        }

        public object Add(schedule entity)
        {
            throw new NotImplementedException();
        }

        public object Delete(schedule entity)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<schedule> GetSite(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<schedule> List(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<schedule> GetAdminWorkshops()
        {
            LibEntities _ncuElrc = new LibEntities();

            var getAdminSched = (from get in _ncuElrc.GetSchedule()
                                 select new schedule
                                 {
                                    lcEventId = get.event_id,
                                    eventDate = get.event_date,
                                    TotalAttendees = get.total_attendees,
                                    LibLastName = get.last_name,
                                    Registerees = get.Registerees.ToString(),
                                    eventDetails = get.event_details

                                 }).ToList();

            _ncuElrc.Connection.Close();

            return getAdminSched;

        }            
    }
}