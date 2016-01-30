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

namespace LibraryMVC4.Controllers
{
    public class UserController : Controller
    {
        private ncuEntities ncuConn = new ncuEntities();
        private IUser<user> _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
            
        }

        public UserController(IUser<user> repository)
        {

            _userRepository = repository;

        }
        
        public ActionResult Index(user _userInfo)
        {
            ViewBag.thisId = LibSecurity.UserId;

            _userInfo = _userRepository.GetUserInfo();
            
            return PartialView("_loginInfo", _userInfo);

        }
     
    }
}
