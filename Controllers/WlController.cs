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
    public class WlController : Controller
    {
        //
        // GET: /Wl/

        private IRepository<wl> _wlrepository;
        private IRepository<structure> _sitemapRepository;

        public WlController() 
        {
            _wlrepository = new WlRepository();
            _sitemapRepository = new SiteMapRepository(); 

        }

        public WlController(IRepository<wl> repository, IRepository<structure> sRepository)
        {
            _wlrepository = repository;
            _sitemapRepository = sRepository;
        }
        
        public ActionResult Index(string id)
        {
      
            if (id != null)
            {
                var keyId = int.Parse(id);


                ViewBag.getCount = _sitemapRepository.GetSite(keyId).Count();

                ViewData["getBread"] = _sitemapRepository.GetSite(keyId);

                using (var _libEntity = new LibEntities())
                {
                    ViewData["getCounts"] = (from ew in _libEntity.elrc_wl_cat
                                             join es in _libEntity.elrc_structure on ew.parent_id equals es.link_data
                                             where es.high_id == keyId
                                             select ew).Count();
                }
              
                return View(_wlrepository.List(id));
            }
            else
            {

                return Content("Page Error");

            }

        }

        public ActionResult GetById(string id)
        {

            var keyId = int.Parse(id);

            using (var _libEntity = new LibEntities())
            {

                ViewData["getCount"] = (from ew in _libEntity.elrc_wl_cat
                                        join es in _libEntity.elrc_structure on ew.parent_id equals es.link_data
                                        where es.high_id == keyId
                                        select ew).Count();
            }

            return View();
        
        }


    }
}
