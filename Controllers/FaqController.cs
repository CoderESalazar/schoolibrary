using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVC4.Entity;
using LibraryMVC4.Models;
using LibraryMVC4.Repository;
using System.Collections;
using System.Reflection;
using LibraryMVC4.Security;

namespace LibraryMVC4.Controllers
{
    public class FaqController : Controller
    {             
        private IFaq<admin> _faqRepository;
        private IAdmin<admin> _adminRepository;
        
        public FaqController()
        {
            _faqRepository = new FaqRepository();
            _adminRepository = new AdminRepository();

        }
        public FaqController(IFaq<admin> repository, IAdmin<admin> adminRepository)
        {
            _faqRepository = repository;
            _adminRepository = adminRepository;
        }
        public ActionResult Index()
        {
            var catList = _adminRepository.GetCatList();

            return View(catList);
        }

        public ActionResult LibCat(string id)
        {
            //page for viewing all faqs by category
            var browseList = _faqRepository.BrowseByCat(id);
            return View(browseList);

        }
        [Authorize()]
        public ActionResult FaqView(string id)
        {
            //method for viewing a single FAQ
            var ids = int.Parse(id);

            //try moving this line of code to the repository

            using (var _libEntity = new LibEntities())
            {
                var userCheck = _libEntity.quest_fdbk.FirstOrDefault(f => f.q_id == ids && f.fdbk_user_id == LibSecurity.UserId);
       
                if (userCheck != null)
                {
                    ViewBag.Message = "Thank you for reviewing this FAQ.";

                }
            }
            var faq = _faqRepository.GetByFaq(ids);

            return View(faq);
        }     
        [HttpPost]
        public ActionResult FaqAnswer(string button, int id)
        {
            //debug this code below and see if it works. 
            var addFeedback = _faqRepository.AddUserFeedback(button, id);

            return RedirectToAction("FaqView", new { id = id.ToString() });
            
         }
    }
}
