using System.Linq;
using System.Web.Mvc;
using LibraryMVC4.Models;
using LibraryMVC4.Repository;
using LibraryMVC4.Controllers.Attributes;
using System.Threading.Tasks;
using System.Data;

namespace LibraryMVC4.Controllers
{
    [LibraryAdmin]
    public class CourseGuideController : Controller
    {
        private readonly IGuides<guides> _guideRepository;
        private readonly IRepository<guides> _courseGuideRepository;

        public CourseGuideController()
        {
            _courseGuideRepository = new CourseGuideRepository();
            _guideRepository = new GuideRepository();
        }

        public CourseGuideController(IRepository<guides> repository, IGuides<guides> repo)
        {
            _courseGuideRepository = repository;
            _guideRepository = repo;
        }       

        public async Task<ActionResult> Admin(string filter = null)
        {
            var getAdmin = await Task.Run(() => _courseGuideRepository.List(filter));

            return View(getAdmin);
        }

        public ActionResult EditGuide(int id, int headerId = 0)
        {
            GetHeaderBody(id, headerId);
            
            var getMyGuide = _guideRepository.GetGuideTabs(id);

            if (headerId != 0)
            {
                ViewBag.headerId = headerId;
            }            

            ViewBag.guideId = id;

            return View(getMyGuide);
        }
         //method will retrieve my tabs
        public ActionResult GetHeaderBody(int id, int headerId = 0)
        {
            ViewBag.HeaderId = headerId;
  
            var getHeaderBody = _guideRepository.GetGuideBody(id, headerId);

            return PartialView("GetHeaderBody", getHeaderBody);
            
        }
                
       public ActionResult TabList()
        {
            
            guides MyTabList = new guides();
            
            var getTabList = _guideRepository.GetTabs();

            MyTabList.TabList = getTabList.Select(c => new SelectListItem()

                {
                    Text = c.TabName,
                    Value = c.TabId.ToString()

                });

            return PartialView("TabList", MyTabList);
        }

        //Trying to make this process without using a post attribute. See if this works. 
        public ActionResult AddCourseGuide(string id, int uId)
        {
            var addCourseGuide = _guideRepository.AddCourseGuide(id);      
            
            return Redirect("/courseguide/admin?page=" + uId);

        }
     
        [HttpPost]
        public JsonResult AddTab(string id)
        {
            var addTab = _guideRepository.AddTab(id);

            return Json(addTab);
        }

        [HttpPost]
        public JsonResult AddNewTab(int guideId, int tabId)
        {
            var addNewTab = _guideRepository.AddNewTab(guideId, tabId);

            return Json(addNewTab);

        }

        [HttpPost]
        public JsonResult UpdateCourseGuide([Bind(Include = "GuideId,HeaderId,HeaderBody,DisplayId,GuideBody")] guides data)
        {            
            var updateCourseGuide = _courseGuideRepository.Edit(data);

            //return Json(Redirect("/CourseGuide/EditGuide/" + data.GuideId + "#UpdateSuccessful"));
            return Json(updateCourseGuide);
        }

        [HttpPost]
        public JsonResult DeleteTab(int guideId, int headerId = 0)
        {
            var deleteTab = _guideRepository.DeleteTab(guideId, headerId);

            return Json(deleteTab);

        }

   }
}
