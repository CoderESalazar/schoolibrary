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
    [LibraryAdmin]
    public class SearchController : Controller
    {        
        private IAdmin<admin> _adminRepository;
        private ISearch<admin> _searchRepository;

        public SearchController()
        {
           _adminRepository = new AdminRepository();
           _searchRepository = new SearchRepository();
        }
        public SearchController(IAdmin<admin> repository, ISearch<admin> searchRepository)
        {
            _searchRepository = searchRepository;
            _adminRepository = repository;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult UserSearch(string UserId) 
        {
            //I believe we are going to start with searching by userid. The question here is whether I want an auto populate list or not. 
            //if we type in the userid then when we click a specific list item then the table is generated below. which will have the q-id. 
            //let's go ahead and write the query, either way we are going to use Json to return the results. Yes. we'll worry about the front-end later.
            if (UserId != null)
            {
                var id = UserId.Trim();

                var getResults = _searchRepository.GetUListNames(id);              
                return Json(getResults, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
                        
        }
        [HttpGet]
        public JsonResult BooleanSearch(string firstKeyWord, string secondKeyWord, string dropdown)
        {

            //we need to create the switch in the repository 

            string a = firstKeyWord.Trim();
            string b = secondKeyWord.Trim();
            string c = dropdown;

            var getSearch = _searchRepository.SearchByKeyWords(a, b, c);
            
            return Json(getSearch, JsonRequestBehavior.AllowGet);

        }
        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = Int32.MaxValue
            };
        }
        [HttpGet]
        public JsonResult QidSearch(int id)
        {
            var getQId = _searchRepository.GetByQId(id);

            if (getQId == null)
            {

                return Json(1, JsonRequestBehavior.AllowGet);

            }

            return Json(getQId, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetCourseSearch(string id)
        {
            var getCourseSearch = _searchRepository.GetCourse(id);

            return Json(getCourseSearch, JsonRequestBehavior.AllowGet);
        }        
    }
}
