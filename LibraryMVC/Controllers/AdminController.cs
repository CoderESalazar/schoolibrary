using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using LibraryMVC4.Entity;
using LibraryMVC4.Models;
using LibraryMVC4.Repository;
using System.Collections;
using System.Net.Mail;
using System.Configuration;
using System.Web.Security;
using LibraryMVC4.Security;
using System.Data.Objects;
using System.IO;
using PagedList;
using LibraryMVC4.Controllers.Attributes;

namespace LibraryMVC4.Controllers
{

    [LibraryAdmin]
    public class AdminController : Controller
    {
        //This is the Library Workspace area for the Library site. Will be comprised of Library Workspace Area, Questions Submitted to KB, Search Workspace, and Categories. 

        private IAdmin<admin> _adminRepository;
        private IUser<user> _userRepository;

        public AdminController()
        {
            _adminRepository = new AdminRepository();
            _userRepository = new UserRepository();

        }
        public AdminController(IAdmin<admin> repository, IUser<user> userRepository)
        {
            _userRepository = userRepository;
            _adminRepository = repository;
        }
        public ActionResult Index()
        {           
            return View();         

        }
        public ActionResult LibraryWkSpace(int? page, string sortOrder)
        {

            //used to keep sort order while paging, see view paging for currentsort
            ViewBag.CurrentSort = sortOrder;

            ViewBag.DateParam = String.IsNullOrEmpty(sortOrder) ? "date_asc" : "";
            ViewBag.CatSortParam = sortOrder == "cat_desc" ? "cat_asc" : "cat_desc";
            ViewBag.QTypeParam = sortOrder == "qtype_desc" ? "qtype_asc" : "qtype_desc";

            var KbQuestions = _adminRepository.GetList();

            switch (sortOrder)
            {
                case "date_asc":

                    KbQuestions = KbQuestions.OrderBy(d => d.LibDateTime);
                    break;

                case "cat_asc":

                    KbQuestions = KbQuestions.OrderBy(d => d.Category);
                    break;

                case "cat_desc":

                    KbQuestions = KbQuestions.OrderByDescending(d => d.Category);
                    break;

                case "qtype_asc":

                    KbQuestions = KbQuestions.OrderBy(d => d.QuestType);
                    break;

                case "qtype_desc":

                    KbQuestions = KbQuestions.OrderByDescending(d => d.QuestType);
                    break;

                default:

                    KbQuestions = KbQuestions.OrderByDescending(d => d.LibDateTime);
                    break;

            }

            //this will display questions in Library KnowledgeBase table/queque. 
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(KbQuestions.ToPagedList(pageNumber, pageSize));

        }
        //this action will display ask a librarian questions
        public ActionResult GetAskLibQs(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            ViewBag.LibUserId = LibSecurity.UserId;

            var getAskLibQs = _adminRepository.GetAll();

            return View(getAskLibQs.ToPagedList(pageNumber, pageSize));

        }
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult GetAskLibQ(string id)
        {
            //This will pull up the individual page for the library questions submitted to the library knowledgebase.     
            ViewBag.LibUserId = LibSecurity.UserId;
            var keyId = int.Parse(id);

            GetCheckBox(keyId);

            var getAskLibQ = _adminRepository.GetById(keyId);

            return View(getAskLibQ);

        }
        //this will generate a category dropdown list for Library workspace. 
        public ActionResult GetCatList(admin catList)
        {
            var getCatList = _adminRepository.GetCatList();

            catList.GetCatList = getCatList.Select(x => new SelectListItem()
            {
                Text = x.CatName,
                Value = x.CatId.ToString()

            });

            return PartialView(catList);
        }
        public ActionResult GetCheckBox(int id)
        {

            var getCheckBox = _adminRepository.GetCheckBox(id);

            return PartialView(getCheckBox);

        }
        [HttpPost]
        public ActionResult LibAreaPost(admin _objUpdate)
        {
            var libAreaPost = _adminRepository.Edit(_objUpdate);

            var Category = _objUpdate.CatQId;
            
            if (Category == "Submitted to KB")
            {
                return Redirect("/admin/LibraryWkSpace");
            }
           
            return Redirect("/admin/GetAskLibqs");  
        }
        [HttpPost]
        public ActionResult SubmittedToKbPost(admin _objUpdate)
        {
            var libAreaPost = _adminRepository.Edit(_objUpdate);

            return Redirect("/admin/LibraryWkSpace");

        }
        public ActionResult SubmittedQs()
        {
            var submittedQs = _adminRepository.GetSubmittedQs();

            return PartialView(submittedQs);

        }
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult AssignQ(string id)
        {
            ViewBag.LibUserId = LibSecurity.UserId;
            var keyId = int.Parse(id);

            var getSubQ = _adminRepository.GetAssignQ(keyId);

            return View(getSubQ);

        }
        public ActionResult LibAssignQs(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var getLibAssignQs = _adminRepository.GetAssignQs();

            return PartialView(getLibAssignQs.ToPagedList(pageNumber, pageSize));

        }
        public ActionResult GetLibQsNo(int? page, string sortOrder)
        {
            //this queue is for Questions Not Submitted to the Library KnowledgeBase.  
            //used to keep sort order while paging, see view paging for currentsort
            //need to access the FileDownload method and make FileAvail a link so the file can be downloaded. 

            ViewBag.CurrentSort = sortOrder;

            ViewBag.DateParam = String.IsNullOrEmpty(sortOrder) ? "date_asc" : "";
            ViewBag.CatSortParam = sortOrder == "cat_desc" ? "cat_asc" : "cat_desc";
            ViewBag.QTypeParam = sortOrder == "qtype_desc" ? "qtype_asc" : "qtype_desc";

            var getGetQsNo = _adminRepository.GetSubmittedQsNo();

            switch (sortOrder)
            {
                case "date_asc":

                    getGetQsNo = getGetQsNo.OrderBy(d => d.LibDateTime);
                    break;

                case "cat_asc":

                    getGetQsNo = getGetQsNo.OrderBy(d => d.Category);
                    break;

                case "cat_desc":

                    getGetQsNo = getGetQsNo.OrderByDescending(d => d.Category);
                    break;

                case "qtype_asc":

                    getGetQsNo = getGetQsNo.OrderBy(d => d.QuestType);
                    break;

                case "qtype_desc":

                    getGetQsNo = getGetQsNo.OrderByDescending(d => d.QuestType);
                    break;

                default:

                    getGetQsNo = getGetQsNo.OrderByDescending(d => d.LibDateTime);
                    break;

            }
            
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return PartialView(getGetQsNo.ToPagedList(pageNumber, pageSize));

        }
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult GetAssignedQ(string id)
        {
            //this will return the Librarian assigned q's for tables Librarian Assigned Q's. 
            var keyId = int.Parse(id);

            var getAssignedQ = _adminRepository.GetByKeyId(keyId);

            //setting a session here so that id can be passed to post. 

            Session["quest_id"] = getAssignedQ.QuestId;

            return View(getAssignedQ);
        }
        public ActionResult GetCatQs(admin getcategories)
        {

            List<SelectListItem> list = new List<SelectListItem>()
            {

                new SelectListItem(){ Value="Partial", Text="Leave in Queue" },
                new SelectListItem(){ Value="Not Submitted to KB", Text="Not Submitted to KB" },
                new SelectListItem(){ Value="Submitted to KB", Text="Submitted to KB" }

            };

            //getcategories = new admin();
            getcategories.GetCatQs = new SelectList(list, "Value", "Text");

            ModelState.Clear();
            return PartialView(getcategories);
        }
        public ActionResult QType(admin qType)
        {

            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){ Value="Phone", Text= "Phone" },
                new SelectListItem(){ Value="Email", Text= "Email" },
                new SelectListItem(){ Value="Chat", Text= "Chat" },
                new SelectListItem(){ Value="Consult", Text= "Consultation" },
                new SelectListItem(){ Value="ServiceD", Text= "Service Desk" }

            };
            qType.QType = new SelectList(list, "Value", "Text");

            ModelState.Clear();
            return PartialView(qType);
        }
        public ActionResult ReAssign(admin dList)
        {
            //this will generate a dropdown list for Library workspace. 

            var reAssign = _adminRepository.GetLibAdminPeople();

            dList.GetLibrarian = reAssign.Select(x => new SelectListItem()
            {
                Text = x.LibName,
                Value = x.LibStringId
            });

            ModelState.Clear();
            return PartialView(dList);
        }
        [HttpPost]
        public ActionResult ReAssignLib(admin _objId)
        {

            var getId = int.Parse(Session["quest_id"].ToString());
            var reAssignLib = _adminRepository.EditLibPerson(_objId, getId);


            //ModelState.Clear();
            return Redirect("/admin/GetAskLibqs");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var deleteQId = _adminRepository.Delete(id);

            if (Convert.ToBoolean(deleteQId) == false)
            {

                ModelState.AddModelError(string.Empty, "Unable to delete record.");
                //return Content("Sorry, unsuccessful delete!");

            }

            return Redirect("/admin/GetAskLibqs");
        }
        public ActionResult Categories()
        {
            var getCatList = _adminRepository.List();

            return View(getCatList);

        }
        public ActionResult CategoriesEdit(int id)
        {
            var getCatInfo = _adminRepository.CategoryEdit(id);
            return View(getCatInfo);
        }

        [HttpPost]
        public ActionResult UpdateCategories(admin _objList)
        {
            var updateCat = _adminRepository.EditCategory(_objList);
            return Redirect("/admin/Categories");
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostCategory(admin _object)
        {
            var postCat = _adminRepository.Add(_object);

            return Redirect("/admin/Categories");

        }
        public ActionResult PhoneChatEmail()
        {
            ViewBag.LibUserId = LibSecurity.UserId;
            ViewBag.UrlPath = Request.Url.Host;

            return View();
        }

        [HttpPost]
        public ActionResult PostPhoneChatEmail(admin _objectList)
        {
            double patronId;

            bool patronIdInteger = double.TryParse(_objectList.PatronId, out patronId);

            if (patronIdInteger == true)
            {
                var postPCE1 = _adminRepository.AddPhoneQt(_objectList);
            }
            else
            {
                return Content("Please be sure that PatronId is a number! Try again.");
            }            
            return Redirect("/admin/GetAskLibqs");

        }
        [HttpGet]
        public JsonResult GetPatronDetails(string SearchString)
        {
            if (SearchString != null)
            {
                var id = SearchString.Trim();

                var getPatronDetails = _adminRepository.PatronInfo(id);
                return Json(getPatronDetails, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public ActionResult PostAssignQ(admin _objItems)
        {

            var postAssignedQ = _adminRepository.AddQ(_objItems);

            if (Convert.ToBoolean(postAssignedQ) == false)
            {
                return Content("Sorry, this question has already been assigned. Or, you have experienced an error!");
            }
            else
            {
                //ModelState.Clear();
                return Redirect("/admin/GetAskLibqs");
            }
        
        }
        public ActionResult GetFeedback()
        {

            var getFeedback = _adminRepository.GetFeedBack();

            return View(getFeedback);


        }
    }
}
