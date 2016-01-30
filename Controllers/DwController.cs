using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVC4.Repository;
using LibraryMVC4.Models;
using LibraryMVC4.Security;

namespace LibraryMVC4.Controllers
{
    public class DwController : Controller
    {
        private IRepository<structure> _repository;
        private IRepository<structure> _sitemapRepository;
        
         public DwController() 
        { 
            _repository = new DwRepository();
            _sitemapRepository = new SiteMapRepository(); 
        }
        public DwController(IRepository<structure> repository, IRepository<structure> sRepository)
        {
            _repository = repository;
            _sitemapRepository = sRepository;
        }
     
        public ActionResult Index(int id)
        {                        
            ViewBag.getCount = _sitemapRepository.GetSite(id).Count();

            ViewData["getBread"] = _sitemapRepository.GetSite(id);             
            
            var dwP = _repository.List(id);
            return View(dwP);
          
        }
    

    }
}
