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
    public class MmController : Controller
    {
        //
        // GET: /Mm/

        private IRepository<structure> _mmRepository;
        private IRepository<structure> _sitemapRepository;
       
        public MmController()  
        {
            _mmRepository = new MmRepository();
            _sitemapRepository = new SiteMapRepository();             
        }
        public MmController(IRepository<structure> repository, IRepository<structure> sRepository)
        {
            _mmRepository = repository;
            _sitemapRepository = sRepository; 
        }

        public ActionResult Index(int id)
        {
            ViewBag.getCount = _sitemapRepository.GetSite(id).Count();

            ViewData["getBread"] = _sitemapRepository.GetSite(id);

            ViewData["getMmTitle"] = _mmRepository.GetSite(id);

            return View(_mmRepository.List(id));
        }

    }
}
