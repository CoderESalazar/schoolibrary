using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVC4.Repository;
using LibraryMVC4.Models;
using LibraryMVC4.Security;
using LibraryMVC4.Controllers.Attributes;

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
        [LibraryAdmin]
        public ActionResult Admin()
        {
            var dwAdmin = _repository.GetAll();

            return View(dwAdmin);
        }

        [LibraryAdmin]
        public ActionResult Edit(int id)
        {
            var dwEdit = _repository.GetById(id);

            return View(dwEdit);
        }

        [HttpPost]
        public ActionResult UpdateDw(structure _dwItems)
        {
            var updateDw = _repository.Edit(_dwItems);

            string msg = "#Page Successfully Updated!";

            return Redirect("/Dw/Admin" + msg);
        }

        [HttpPost]
        public ActionResult DeleteDw(structure _objId)
        {
            var deleteDw = _repository.Delete(_objId);

            string msg = "#Page Successfully Deleted";

            return Redirect("/Dw/Admin" + msg);

        }

        [LibraryAdmin]
        public ActionResult AddDw()
        {
            return View();

        }

        [HttpPost]
        public ActionResult AddDwPage(structure _addObj)
        {
            var addDwPage = _repository.Add(_addObj);

            string msg = "#Page Successfully Added!";

            return Redirect("/Dw/Admin" + msg);
        }

    }
}
