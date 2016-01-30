using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryMVC4.Models;
using LibraryMVC4.Entity;
using System.Data.Objects.SqlClient;
using LibraryMVC4.Security;
using Ncu.Logging.Logger;

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
            using (var _ncuElrc = new LibEntities())
            {
                bool result = false;
                lib_calendar lc = _ncuElrc.lib_calendar.FirstOrDefault(t => t.event_id == entity.lcEventId);

                try
                {
                    lc.lib_home = entity.workShopTitle;
                    lc.event_date = entity.eventDate;
                    lc.total_attendees = entity.TotalAttendees;
                    lc.event_details = entity.eventDetails;

                    _ncuElrc.SaveChanges();
                    result = true;
                }
                catch (Exception e)
                {
                    ExceptionLogger.Log(ExceptionLogger.SeverityLevels.fatal, e, "Next action is to re-throw this exception object");
                    result = false;
                }
                finally
                {
                    _ncuElrc.Connection.Close();
                }
                return result;
            }

        }

        public object Add(schedule entity)
        {

            LibEntities _ncuElrc = new LibEntities();
            bool result = false;

            try
            {
                var addEvent = new lib_calendar
                {
                    lib_home = entity.workShopTitle,
                    event_date = entity.eventDate,
                    event_details = entity.eventDetails,
                    lib_instructor_id = LibSecurity.UserId,
                    date_time = DateTime.Now,         

                 };
                _ncuElrc.lib_calendar.AddObject(addEvent);
                _ncuElrc.SaveChanges();

                result = true;
            }
            catch(Exception e)
            {
                ExceptionLogger.Log(ExceptionLogger.SeverityLevels.fatal, e, "Next action is to re-throw this exception object");
            }
            finally
            {
                _ncuElrc.Connection.Close();
            }

            return result;

        }

        public object Delete(schedule entity)
        {
            using (var _ncuElrc = new LibEntities())
            {

                var deleteRegistrant = _ncuElrc.lib_registerees.FirstOrDefault(t => t.key_id == entity.lcEventId);

                if (deleteRegistrant == null)
                {
                    return false;
                }
                else
                {
                    _ncuElrc.DeleteObject(deleteRegistrant);
                    _ncuElrc.SaveChanges();

                    return true;
                }
            }
        }


        public IEnumerable<schedule> GetSite(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<schedule> List(int id)
        {
            var _ncuElrc = new LibEntities();
            
                var getRegisterees = (from r in _ncuElrc.lib_registerees
                                      where r.event_id == id
                                      select new schedule
                                      {
                                          PatronName = r.first_name + " " + r.last_name,
                                          PatronEmail = r.email_address,
                                          DateTime = r.date_time,
                                          lcEventId = r.key_id

                                      }).ToList();

            _ncuElrc.Connection.Close();
            _ncuElrc.Dispose();
            
            return getRegisterees;     

        }

        public IEnumerable<schedule> GetAdminWorkshops()
        {
            LibEntities _ncuElrc = new LibEntities();

            try
            {
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

                return getAdminSched;
            }

            catch (Exception e)
            {

                ExceptionLogger.Log(ExceptionLogger.SeverityLevels.fatal, e, "Next action is to re-throw this exception object");

            }
            
            finally {
                
                _ncuElrc.Connection.Close();
                _ncuElrc.Dispose();
        
            }

            return null;

        }
       


        public schedule GetEvents(int id)
        {
            LibEntities _ncuElrc = new LibEntities();

            var getEvents = (from lc in _ncuElrc.lib_calendar
                             where lc.event_id == id
                             select new schedule
                             {
                                 lcEventId = lc.event_id,
                                 eventDate = lc.event_date,
                                 workShopTitle = lc.lib_home,
                                 TotalAttendees = lc.total_attendees,
                                 eventDetails = lc.event_details

                             }).FirstOrDefault();

            _ncuElrc.Connection.Close();
            _ncuElrc.Dispose();

            return getEvents;
        }

        public object DeleteEvent(int id)
        {
            using (var _ncuElrc = new LibEntities())
            {
                var deleteEvent = _ncuElrc.lib_calendar.FirstOrDefault(t => t.event_id == id);

                if (deleteEvent == null)
                {
                    return false;
                }
                else
                {
                    _ncuElrc.DeleteObject(deleteEvent);
                    _ncuElrc.SaveChanges();

                    return true;
                }
            }
        
        }
    }
}