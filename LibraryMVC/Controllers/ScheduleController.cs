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
        public ActionResult Index()
        {
            var getSchedule = _scheduleRepository.GetAll();

            return View(getSchedule);
        }
        //controller for LeaveWorkshopfeedback
        public ActionResult LeaveWorkshopFdbk()
        {
            return Redirect("https://ncu.co1.qualtrics.com/jfe/form/SV_4Ux4PIwTA7WsQsZ");
        }
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
        //[LibraryAdmin]
        public ActionResult GetAdminSchedule()
        {
            var getAdminSchedule = _schedulerR.GetAdminWorkshops();
            //var getAdminSchedule = _scheduleRepository.
                
            return View(getAdminSchedule);
        }
  
    }
}
