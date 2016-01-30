using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVC4.Entity;
using LibraryMVC4.Models;
using LibraryMVC4.Repository;
using System.Collections;
using LibraryMVC4.Security;
using LibraryMVC4.Controllers.Attributes;

namespace LibraryMVC4.Controllers
{
    //[Authorize()]
    public class ScheduleController : Controller
    {
        //
        // GET: /Schedule/
        private IRepository<schedule> _scheduleRepository;
        private IUser<user> _userRepository;
        private ISchedule<schedule> _schedulerR;

        public ScheduleController()
        {
            _scheduleRepository = new ScheduleRepository();
            _userRepository = new UserRepository();
            _schedulerR = new ScheduleRepository();

        }
        public ScheduleController(IRepository<schedule> repository, IUser<user> userRepository, ISchedule<schedule> schedRep)
        {
            _userRepository = userRepository;
            _scheduleRepository = repository;
            _schedulerR = schedRep;

        }

        [Authorize()]
        public ActionResult Index()
        {
            var getSchedule = _scheduleRepository.GetAll();

            return View(getSchedule);
        }

        //controller for LeaveWorkshopfeedback
        //[Authorize()]
        public ActionResult LeaveWorkshopFdbk()
        {
            return Redirect("https://ncu.co1.qualtrics.com/jfe/form/SV_4Ux4PIwTA7WsQsZ");
        }
        [Authorize()]
        public ActionResult RegisterMe(int id)
        {
            var t = _userRepository.GetUserInfo();

            var c = _scheduleRepository.GetById(id);

            //let's move this code into the repository
            //if student is not registered go ahead and add them to the table otherwise let's not add them multiple times to the table. 
            if (c == null)
            {                
               return Content("You are already registered for this event.");
            }
            return View(c);
        }
        [LibraryAdmin]
        public ActionResult GetAdminSchedule()
        {
            var getAdminSchedule = _schedulerR.GetAdminWorkshops();

            return View(getAdminSchedule);
        }

        [LibraryAdmin]
        public ActionResult GetEvent(int id)
        {
            var getEvent = _schedulerR.GetEvents(id);

            return View(getEvent);            
        }

        [LibraryAdmin]
        public ActionResult AddEvent()
        {
            //this will be our Add form page. Best to handle this on a separate page and set the proper client-side validation. 

            return View();
        }

        [LibraryAdmin]
        public ActionResult Registerees(int id)
        {
            var getRegisterees = _scheduleRepository.List(id);

            return View(getRegisterees);
        }
        
        [HttpDelete]
        public JsonResult DeleteRegisteree(schedule json)
        {
            var deleteRegisteree = _scheduleRepository.Delete(json);

            if ((bool)deleteRegisteree == true)
            {
                string message = "Registerant Deleted!";
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            else 
            {
                string message = "An error has occurred!";
                return Json(message, JsonRequestBehavior.AllowGet);
            }            
        }

        [HttpPost]
        public ActionResult UpdateGetEvent(schedule objContent)
        {
            var updateGetEvent = _scheduleRepository.Edit(objContent);

            return Redirect("/schedule/GetAdminSchedule");

        }
        [HttpPost]
        public ActionResult DeleteEvent(int id)
        {
            var deleteEvent = _schedulerR.DeleteEvent(id);

            if ((bool)deleteEvent == true)
            {
                string message = "Event successfully deleted! Click here to return to the <a href=/schedule/GetAdminSchedule>Library Schedule Admin Area</a>.";

                return Content(message);               
            } 
            else
            { 
                string message = "An unexpected error has occurred.";

                return Content(message);
            }
        }
        [HttpPost]
        public ActionResult AddAnEvent(schedule _addEvent)
        {
            var addAnEvent = _scheduleRepository.Add(_addEvent);            

            if ((bool)addAnEvent == true)
            {
                string message = "Event successfully added! Click here to return to the <a href=/schedule/GetAdminSchedule>Library Schedule Admin Area</a>.";

                return Content(message); 

            }
            else
            {
                string message = "An unexpected error has occurred.";

                return Content(message);
            }          
           
        }
    }
}
