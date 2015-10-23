using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVC4.Models;
using LibraryMVC4.Repository;
using LibraryMVC4.Entity;

namespace LibraryMVC4.Controllers
{
    public class SiteMapController : Controller
    {
        private IRepository<structure> _sitemapRepository;             

         public SiteMapController()
        {
            _sitemapRepository = new SiteMapRepository();
        }
         public SiteMapController(IRepository<structure> sRepository)
        {
            _sitemapRepository = sRepository;
        }
      
        public ActionResult GetSiteMap()
        {
            var getSiteMap = _sitemapRepository.GetAll();

            return View(getSiteMap);           
            
        }

    }
}
