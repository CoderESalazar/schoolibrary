using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVC4.Repository;
using LibraryMVC4.Models;
using LibraryMVC4.Entity;


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
        
        public FaController(IRepository<fa> repository, IRepository<structure> srepository)
        {
            _faRepository = repository;
            _sitemapRepository = srepository; 
        }
        
        public ActionResult Index(string id)
        {

            var keyId = int.Parse(id);

            ViewBag.getCount = _sitemapRepository.GetSite(keyId).Count();
            
            ViewData["getBread"] = _sitemapRepository.GetSite(keyId);

            ViewData["getTitle"] = _faRepository.List(keyId);

            return View(_faRepository.List(id));
        }
 
    }
}
       
