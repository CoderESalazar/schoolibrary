using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVC4.Entity;
using LibraryMVC4.Models;
using LibraryMVC4.Repository;
using System.Configuration;
using System.Web.Security;
using LibraryMVC4.Security;
using System.Threading.Tasks;

namespace LibraryMVC4.Controllers
{
    public class HomeController : Controller
    { 
        private IHome<home> _homeRepository;
        private IUser<user> _userRepository;
        private IAdmin<admin> _adminRepository;
               
        public HomeController() 
        {
            _homeRepository = new HomeRepository();
            _userRepository = new UserRepository();
            _adminRepository = new AdminRepository();           
        }

        public HomeController(IHome<home> repository, IUser<user> userRepository, IAdmin<admin> adminRepository)
        {
            _userRepository = userRepository;
            _homeRepository = repository;
            _adminRepository = adminRepository;            
        }

        public ActionResult Index()
        {
            using (var _libEntity = new LibEntities())
            {
                if (!string.IsNullOrEmpty(LibSecurity.UserId))
                {
                    LibSecurity.IsLoggedIn = true;

                    ViewBag.IsLoggedIn = LibSecurity.UserId;

                    //Viewed emails count script
                    string id = LibSecurity.UserId;
                    var getMail = _libEntity.GetMessageCount(id);
                    int ordercount = getMail.SingleOrDefault().Value;

                    Session["theCount"] = "Messages: " + ordercount;

                }
                else
                {
                    LibSecurity.IsLoggedIn = false;
                }
                return View();
            }
        }

        [ChildActionOnly]
        public async Task<ActionResult> BList()
        {
            var getPosts = await Task.Run(() => _homeRepository.GetBlogPosts());

            return View(getPosts);            
         }
        [ChildActionOnly]
        public async Task<ActionResult> DirMessage()
        {
            var getDirMessage = await Task.Run(() => _homeRepository.GetDirMessage());

            return View(getDirMessage);
        
        }
        [ChildActionOnly]
        public async Task<ActionResult> Chat() 
        {
           
            var getChat = await Task.Run(() => _homeRepository.GetChat());                                      
            return View(getChat);    
            
        }
       [ChildActionOnly]
        public async Task<ActionResult> ResMonth()
        {
            var resMonth = await Task.Run(() => _homeRepository.ResourceOfMonth());
            return View(resMonth); 

        }
        [Authorize()]
        public ActionResult ReturnResMonth(string entryId)
        {
            //check this out in debug mode to see if i can issue with resource of the month
            using (var _libEntity = new LibEntities())
            {
                int reEntryId = Convert.ToInt32(entryId);

                var userCheck = _libEntity.resources_tb_fdbk.FirstOrDefault(x => x.entry_id == reEntryId && x.user_id == LibSecurity.UserId);

                var getUsers = _libEntity.resources_tb_fdbk.Where(x => x.entry_id == reEntryId).Count();

                //we can that if userCheck is not null then we can do a count. Otherwise, there is no count. 
                if (userCheck != null)
                {
                    ViewBag.Message = "Thank you for reviewing this resource.";
                    ViewBag.theCount = getUsers;
                    ViewBag.Id = true;

                }
                else
                {
                    ViewBag.theCount = getUsers;

                }
                var getResMonth = _homeRepository.SumResourceMonth(entryId);

                ViewBag.GetSum = getResMonth.ToList().Select(c => c.Ratings).Sum();

                return View(getResMonth);
            }
            
            //write private method to acquire total number of respondents. 
        }
         public ActionResult LibFaq(home model)
        {
            var libFaq = _adminRepository.GetCatList(); 

            model.FaqList = libFaq.Select(x => new SelectListItem()
            {
                Text = x.CatName, 
                Value = x.CatId.ToString()

            });

           return View(model);            
        }

        public async Task<ActionResult> GetAlert()
        {
            var alertMess = await Task.Run(() => _homeRepository.GetAlert());

            return View(alertMess);        
                        
        }

        [Authorize()]
        public ActionResult ScheduleConsult()
        {
            var model = new mail();

            return View(model);
        }
        //controller for leaving a feedback on the Research Consult Survey
        [Authorize()]
        public ActionResult LeaveConsultFdbk()
        {
            return Redirect("https://ncu.co1.qualtrics.com/jfe/form/SV_3ryXQEaJc38GjaJ");
        }
        [Authorize()]
        public ActionResult LeaveFeedback()
        {
            LibSecurity.IsLoggedIn = true;
            return View();
        }

        [HttpPost]
        public ActionResult LeaveFeedbackPost(home _objFeedback)
        {
            var myPost = _homeRepository.AddUserPost(_objFeedback);                        
            return View();                
        }

        [HttpPost]
        public ActionResult GetRadioId(home _objModel, int id)
        {
            using (var _libEntity = new LibEntities())
            {
                var userCheck = _libEntity.resources_tb_fdbk.FirstOrDefault(x => x.entry_id == id && x.user_id == LibSecurity.UserId);


                if (_objModel.SelectRadioItem != null || _objModel.Comments != null)
                {
                    var addRadioId = _homeRepository.AddRadioId(_objModel, id);

                    string entryId = id.ToString();

                    return RedirectToAction("ReturnResMonth", new { entryId = id.ToString() });
                }
                else
                {
                    return Content("These are the variables " + id + " , " + _objModel.SelectRadioItem + _objModel.Comments);

                }
            }
        }

        public ActionResult GetRadio()
        {
           home _myRadioList = new home();
            return View(_myRadioList); 
        }

        public ActionResult GetResMonthFdbk()
        {
            return PartialView("ResMonthFdbk"); 
        }

        [Authorize()]
        public ActionResult LogOut()
        {
            LibSecurity.IsLoggedIn = false;

            FormsAuthentication.SignOut();
            Session.Abandon();

            HttpCookie myCookie = new HttpCookie("ASP.NET_SessionId", "");
            myCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(myCookie);

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            return Redirect(ConfigurationManager.AppSettings["CourseRoomLogoutUrl"]); 
            
        }
        [Authorize()]
        public ActionResult LoggedIn()
        {
            LibSecurity.IsLoggedIn = true;
            return Redirect("/home/index");
         }      
        public ActionResult EbscoAdvancedSearch()
        {
            return Redirect("http://search.ebscohost.com.proxy1.ncu.edu/login.aspx?direct=true&type=1&authtype=uid&user=northcentraluniv&password=ebsco&profid=eds");
        }
        [Authorize()]
        public ActionResult ILTutorial()
        {
            return Redirect("https://ncu.co1.qualtrics.com/SE/?SID=SV_bO6kv1MRty0NPuZ");          
        }
        [Authorize()]
        public ActionResult GetFeedback()
        {              
             return Redirect("https://ncu.co1.qualtrics.com/SE/?SID=SV_6lNtDoApW1J6zWJ");
        }
        public ActionResult GetLibraryAdminLink()
        {            
            var sGetAdminInfo = _userRepository.LibAdminGroup();

            return PartialView("_libAdminPerson", sGetAdminInfo);
        }
        public ActionResult RoadrunnerSearch()
        {
            return PartialView("_searchBox");
        }
        [HttpPost]
        public JsonResult FindFaqs(string searchText, int maxResults)
        {
            var getFindFaqs = _homeRepository.FindFaqs(searchText, maxResults);

            return getFindFaqs;
        }

    }
    
                  
}

