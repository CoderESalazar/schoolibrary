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
         public ActionResult GetCGuide(guides model)
        {
            string guideId = model.GuidesId.ToString();

            var gId = int.Parse(guideId);

            string headerId = model.HeaderId.ToString();           
            //if the guide has headers/tabs then this code below is run. 
               if (headerId != "")
               {                 
                   //note this method is called here as well as in the "else" statement. 
                   ViewData.Model = _guideRepository.GetGuideTabs(gId);

                   var hId = int.Parse(headerId);

                   ViewData["GuideBody"] = _guideRepository.GetGuidesWithBody(hId);
                }
                /*there is no headerid when you first select from the drop down menu so this always called first prior to the code above. We can remove this code once every
                every guide is using tabs*/
                else
                {
                   //by default this always get pulled, no matter what. 
                    
                    ViewData["guideNoTabs"] = _guideRepository.GetGuidesWOutBody(gId);
                    ViewData.Model = _guideRepository.GetGuideTabs(gId);                   
   
                }
           return View();           

        }
 
    }


}

