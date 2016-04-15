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
    public class WlController : Controller
    {

        private IRepository<wl> _wlrepository;
        private IRepository<structure> _sitemapRepository;
        private IWl<wl> _wlRepo;

        public WlController()
        {
            _wlrepository = new WlRepository();
            _sitemapRepository = new SiteMapRepository();
            _wlRepo = new WlRepository();
        }

        public WlController(IRepository<wl> repository, IRepository<structure> sRepository, IWl<wl> repo)
        {
            _wlrepository = repository;
            _sitemapRepository = sRepository;
            _wlRepo = repo;
        }

        [LibraryAdmin]
        public ViewResult Admin()
        {
            var getWlPages = _wlrepository.GetAll();

            return View(getWlPages);
        }

        [LibraryAdmin]
        public ViewResult AddWlPage()
        {
            return View();
        }

        public ActionResult Index(string id)
        {

            if (id != null)
            {
                var keyId = int.Parse(id);

                ViewBag.getCount = _sitemapRepository.GetSite(keyId).Count();
                ViewData["getBread"] = _sitemapRepository.GetSite(keyId);
                ViewData["getCounts"] = _wlRepo.GetCounts(keyId);

                return View(_wlrepository.List(id));
            }
            else
            {
                return Content("Page Error");
            }

        }

        [LibraryAdmin]
        public ViewResult GetWlPage(int id)
        {
            var getWlPage = _wlrepository.List(id);

            return View(getWlPage);
        }

        [LibraryAdmin]
        public ViewResult EditHeader(int? id, int pId = 0)
        {
            ViewBag.structId = pId;
            var editHeader = _wlrepository.GetById(id);

            return View(editHeader);
        }

        [LibraryAdmin]
        public ViewResult EditResource(int id, int pId = 0)
        {
            ViewBag.structId = pId;
            var editResource = _wlrepository.GetById(id);

            return View(editResource);
        }

        [LibraryAdmin]
        public ViewResult AddCategory(int id, int pId = 0)
        {
            ViewBag.PrimaryKey = pId;
            ViewBag.HighId = id;
            return View();
        }

        [LibraryAdmin]
        public ViewResult AddLink(int catId, int pId)
        {
            ViewBag.CatId = catId;
            ViewBag.HighId = pId;

            return View();
        }

        [HttpPost]
        public ActionResult UpdateResource(wl _objUpdate)
        {
            var updateLibResource = _wlrepository.Edit(_objUpdate);

            return Redirect("/wl/getwlpage/" + _objUpdate.HighId + "#ResourceUpdated");
        }

        [HttpPost]
        public ActionResult UpdateHeader(wl _objUpdate)
        {
            var updateHeader = _wlRepo.EditHeader(_objUpdate);

            return Redirect("/wl/getwlpage/" + _objUpdate.HighId + "#HeaderUpdated");
        }

        [HttpPost]
        public ActionResult DeleteResource([Bind(Include = "PrimaryKey,ParentId,HighId")] wl _objDelete)
        {
            var deleteResource = _wlrepository.Delete(_objDelete);

            return Redirect("/wl/getwlpage/" + _objDelete.HighId + "#ResourceDeleted");
        }

        [HttpPost]
        public ActionResult DeleteHeader([Bind(Include = "PrimaryKey,ParentId,HighId")] wl _objDelete)
        {
            var deleteHeader = _wlRepo.DeleteHeader(_objDelete);

            return Redirect("/wl/getwlpage/" + _objDelete.HighId + "#HeaderDeleted");
        }

        [HttpPost]
        public ActionResult AddResource(wl _objAdd)
        {
            var addResource = _wlrepository.Add(_objAdd);

            return Redirect("/wl/getwlpage/" + _objAdd.HighId + "#LinkAdded");
        }

        [HttpPost]
        public ActionResult AddWlPage([Bind(Include = "Title")] wl _objAdd)
        {
            var addWlPage = _wlRepo.AddWlPage(_objAdd);
            return Redirect("/wl/admin");
        }

        [HttpPost]
        public ActionResult AddHeader(wl _objAdd)
        {
            var addHeader = _wlRepo.AddHeader(_objAdd);
            return Redirect("/wl/getwlpage/" + _objAdd.HighId + "#HeaderAdded");
        }

        [LibraryAdmin]
        public ViewResult EditTitle(int id)
        {
            ViewBag.HighId = id;
            var editTitle = _wlRepo.EditTitle(id);
            return View(editTitle);
        }

        [HttpPost]
        public ActionResult EditTitle(wl _objEdit)
        {
            var editTitle = _wlRepo.EditPageTitle(_objEdit);
            return Redirect("/wl/getwlpage/" + _objEdit.HighId + "#PageTitleUpdated");
        }

        [HttpPost]
        public ActionResult DeleteWlPage(wl _objDelete)
        {
            var deleteWlPage = _wlRepo.DeleteWlPage(_objDelete);
            return Redirect("/wl/admin/#PageDeleted");
        }
    }
}
