using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVC4.Entity;
using LibraryMVC4.Models;
using LibraryMVC4.Repository;
using System.Collections;
using LibraryMVC4.Controllers.Attributes;

namespace LibraryMVC4.Controllers
{
    public class GuideController : Controller
    {

        private IGuides<guides> _guideRepository;

        public GuideController()
        {
            _guideRepository = new GuideRepository();
        }
        public GuideController(IGuides<guides> repository)
        {
            _guideRepository = repository;
        }
        //[ChildActionOnly]
        public ActionResult Index(guides model)
        {
            //these are the course guides
            var courseGuides = _guideRepository.GetCourseGuides();

            model.GuideList = courseGuides.Select(m => new SelectListItem()
                {

                    Text = m.CourseCode,
                    Value = m.GuidesId.ToString()

                });

            //we are going to try to add our specialization guides below our course guides. 
            var specGuides = _guideRepository.GetSpecTitleList();

            model.SpecList = specGuides.Select(m => new SelectListItem()
            {
                Text = m.GuideTitle,
                Value = m.DeptGuideId.ToString()

            });

            return PartialView("guidesdropdown", model);

        }
        public ActionResult SpecList(guides model)
        {

            var specGuides = _guideRepository.GetSpecTitleList();

            model.SpecList = specGuides.Select(m => new SelectListItem()
            {
                Text = m.GuideTitle,
                Value = m.DeptGuideId.ToString()

            });

            return View("_specguides", model);
        }

        public ActionResult GetGuide(guides model)
        {
            int id = model.DeptGuideId;

            ViewData["getCounts"] = _guideRepository.GetCount(id);

            return View(_guideRepository.GetSpecPage(id));

        }
        //page retrieved after selecting guide. 
        [Authorize]
        public ActionResult GetCGuide(guides model, int GuideId = 0)
        {
            string myId = model.GuidesId.ToString();
            var guideId = int.Parse(myId);

            if (GuideId != 0)
            {

                var thisMyGuide = _guideRepository.GetGuideTabs(GuideId);

                return View(thisMyGuide);

            } else
            {

                if (model.HeaderId != null)
                {
                    ViewBag.headerId = model.HeaderId;
                }    
            
            var getMyGuide = _guideRepository.GetGuideTabs(guideId);
            return View(getMyGuide);

            }                   

        }

        //Library Admin area begins below.

        [LibraryAdmin]
        public ActionResult SpecAdminArea()
        {
            var specAdminArea = _guideRepository.GetSpecGuides();

            return View(specAdminArea);
        }
        [LibraryAdmin]
        public ActionResult SpecGuide(int? id)
        {
            ViewBag.Id = id;

            var specGuide = _guideRepository.GetSpecPage(id);

            return View(specGuide);
            //return Content(id);
        }
        [LibraryAdmin]
        public ActionResult AddSpecPage(int? id)
        {
            GetSpecList(id);

            return View();
        }
        [LibraryAdmin]
        public ActionResult GetSpecList(int? id)
        {
            int specId = Convert.ToInt32(id);

            var getSpecList = _guideRepository.GetSpecListDropDown(specId);
            ViewBag.Id = id;

            guides _dropDown = new guides();

            _dropDown.SpecList = getSpecList.Select(m => new SelectListItem()
            {
                Text = m.SectionName,
                Value = m.SectionName

            });
            return PartialView(_dropDown);
        }
        [HttpPost]
        public ActionResult AddSpec(guides _objDropDown)
        {
            var addSpec = _guideRepository.AddSpec(_objDropDown);

            if ((bool)addSpec == true)
            {
                return Redirect("/guide/SpecAdminArea" + "#Added");
            }
            return Redirect("/guide/SpecAdminArea" + "#ErrorOccurred");
        }
        [LibraryAdmin]
        public ActionResult HeaderPage(int id)
        {
            ViewBag.Id = id;
            var getSpecTitle = _guideRepository.HeaderPage(id);

            return View(getSpecTitle);
        }
        [LibraryAdmin]
        public ActionResult HeaderDropDown()
        {
            var getHeaderDropDown = _guideRepository.GetHeaderDropDown();

            guides _dropDown = new guides();

            _dropDown.HeaderList = getHeaderDropDown.Select(m => new SelectListItem()
            {
                Text = m.SectionName,
                Value = m.SectionName
            });

            return PartialView(_dropDown);
        }
        [HttpPost]
        public ActionResult PostHeaderPage(guides _objItems)
        {
            var postHeader = _guideRepository.AddHeader(_objItems);
            int id = _objItems.DeptGuideId;


            if ((bool)postHeader == true)
            {
                return Redirect("/guide/specguide/" + id + "#HeaderAdded");
            }

            return Redirect("/guide/specguide/" + id + "#HeaderFailure");
        }
        [LibraryAdmin]
        public ActionResult AddResourcePage(int id)
        {
            //bring in existing partial view dbmasterindex dropdown. will likely need to use inheritance to make this work. 
            ViewBag.headerId = id;

            var resourcePage = _guideRepository.ResourcePage(id);

            return View(resourcePage);
        }
        [HttpPost]
        public ActionResult PostResourcePage(guides _objItems)
        {
            int? specId = _objItems.DeptDiscpId;

            var postResourcePage = _guideRepository.AddResource(_objItems);

            if ((bool)postResourcePage == true)
            {
                return Redirect("/guide/specguide/" + specId + "#ResourceAdded");
            }
            else
            {
                return Redirect("/guide/specguide/" + specId + "#Resourcefailed");
            }
        }
        [LibraryAdmin]
        public ActionResult EditResource(int id)
        {
            var editResourcePage = _guideRepository.EditResourcePage(id);
            
            return View(editResourcePage);
        }
        [HttpPost]
        public ActionResult UpdateResource(guides _objItems)
        {
            var updateResource = _guideRepository.EditResource(_objItems);

            return Redirect("/guide/specguide/" + _objItems.DeptDiscpId + "#UpdateSuccessful");
        }
        [HttpPost]
        public ActionResult UpdateHeader(guides _obItems)
        {
            var updateHeader = _guideRepository.UpdateHeader(_obItems);

            if ((bool)updateHeader == true)
            {
                return Redirect("/guide/specguide/" + _obItems.DeptDiscpId + "#HeaderUpdated");
            }
            else
            {
                return Redirect("/guide/specguide/" + _obItems.DeptDiscpId + "#Failure");
            }

        }
        [HttpPost]
        public ActionResult DeleteResource([Bind(Include = "GuideResourceId,DeptDiscpId")] guides _objItems)
        {
            var deleteResource = _guideRepository.DeleteResource(_objItems.GuideResourceId);
            
            return Redirect("/guide/specguide/" + _objItems.DeptDiscpId + "#ResourceDeleted");
        }

        [LibraryAdmin]
        public ActionResult GetHeader(int id)
        {
            var getHeader = _guideRepository.GetHeader(id);

            return View(getHeader);
        }
        [HttpPost]
        public ActionResult DeleteHeader(guides _objItems)
        {
            int? id = _objItems.HeaderId;
            
            var deleteHeader = _guideRepository.DeleteHeader((int)id);

            if ((bool)deleteHeader == false)
            {
                string error = "#RemoveRemainingResourcesFromHeader";

                return Redirect("/guide/specguide/" + _objItems.DeptDiscpId + error);
            }
            string success = "#HeaderSuccessfullyRemoved";
            
            return Redirect("/guide/specguide/" + _objItems.DeptDiscpId + success);

        }
        public ActionResult DisplaySpec(bool boolId, int id)
        {
            var updateDisplay = _guideRepository.UpdateDisplay(boolId, id);

            if ((bool)updateDisplay)
            {
                return Redirect("/guide/SpecAdminArea" + "#Updated");
            }
            return Redirect("/guide/SpecAdminArea" + "#failed");
        }

    }
}

