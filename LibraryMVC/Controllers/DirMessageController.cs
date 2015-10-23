using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVC4.Entity;
using LibraryMVC4.Models;
using LibraryMVC4.Repository;
using System.Collections;

namespace LibraryMVC4.Controllers
{
    public class DirMessageController : Controller
    {
        
        private LibEntities _libEntity = new LibEntities();
        private IRepository<home> _dirMessageRepository;
        
        
        public DirMessageController() 
        {
            _dirMessageRepository = new DirMessageRepository();
        }
         public DirMessageController(IRepository<home> repository)
        {
            _dirMessageRepository = repository;
        }

         public ActionResult Index(int entryId)
        {


            //return Content("Select id: " + entryId);

            var getDirMess = _dirMessageRepository.GetById(entryId);


            return View(getDirMess);
        }

    }
}
