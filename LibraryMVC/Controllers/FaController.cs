using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVC4.Repository;
using LibraryMVC4.Models;
using LibraryMVC4.Entity;
using LibraryMVC4.Controllers.Attributes;


namespace LibraryMVC4.Controllers
{
    public class FaController : Controller
    {        
        private IRepository<fa> _faRepository;
        private IRepository<structure> _sitemapRepository;      
        
        public FaController() 
        {        
            _faRepository = new FaRepository(); 
            _sitemapRepository = new SiteMapRepository();
   
        }
        
        public FaController(IRepository<fa> repository, IRepository<structure> srepository, ISchedule<schedule> scheduleRepository)
        {
            _faRepository = repository;
            _sitemapRepository = srepository;            
        }
        
        public ActionResult Index(int id)
        {
            ViewBag.getCount = _sitemapRepository.GetSite(id).Count();
            
            ViewData["getBread"] = _sitemapRepository.GetSite(id);

            var getFaTitle = _faRepository.List(id);

            GetFaDbList(id);

            return View(getFaTitle);

        }
        public ActionResult GetFaDbList(int id)
        {
            var getFaDbList = _faRepository.GetSite(id);

            if (getFaDbList != null)
            {
                return PartialView(getFaDbList);
            }

            ViewBag.Content = "Please add databases!";

            return ViewBag.Content;
        }

        //FA Admin Area begins below.
        [LibraryAdmin]
        public ActionResult FaAdmin()
        {
            var getSchools = _faRepository.GetAll();

            return View(getSchools);
        }
        [LibraryAdmin]
        public ActionResult FaEdit(int id)
        {
            ViewBag.GetTitle = _faRepository.List(id);

            var getFaPage = _faRepository.GetSite(id);

            ViewBag.DbId = id;

            return View(getFaPage);
        }
        [HttpPost]
        public ActionResult FaDbDelete(fa _objItems)
        {
            var dbPage = _objItems.dbProgId;
            
            var faDbDelete = _faRepository.Delete(_objItems);

            string msg = "#DatabaseDeleted";

            return Redirect("/fa/faedit/" + dbPage + msg);

        }
        [HttpPost]
        public ActionResult AddDb(fa _objItems)
        {
            int dbPage = _objItems.HighId;

            var addDb = _faRepository.Add(_objItems);

            if ((bool)addDb == true)
            {
                return Redirect("/fa/faedit/" + dbPage + "#DbAdded");
            }
           return Content("Database reference on this page already exists!");
        }
 
    }
}
       
