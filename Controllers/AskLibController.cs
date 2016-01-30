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
using PagedList;
using System.Web.Security;
using LibraryMVC4.Security;


namespace LibraryMVC4.Controllers
{
    [Authorize()]
    public class AskLibController : Controller
    {
        private IAskLib<asklib> _askRepository;
        private IAdmin<admin> _adminRepository;

        public AskLibController()
        {
            _askRepository = new AskLibRepository();
            _adminRepository = new AdminRepository();
        }

        public AskLibController(IAskLib<asklib> repository, IAdmin<admin> adminRepository)
        {
            _adminRepository = adminRepository;
            _askRepository = repository;
        }

        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(_askRepository.GetAllUserQs().ToPagedList(pageNumber, pageSize));

        }
        public ActionResult GetAnswer(string id)
        {
            using (var _libEntity = new LibEntities())
            {
                /*
                tried to move this to the repository but there are issues with lambdas 
                and interfaces. Just not sure if there is a way to bring these types of statements
                into a repository where things are strongly typed to models. 9/28/2015
                */

                ViewBag.LibEmail = "library.ncu.edu?subject=" + id;

                var keyId = int.Parse(id);

        
                var fileName = _libEntity.file_uploads.FirstOrDefault(f => f.q_id == keyId);

                if (fileName != null)
                {
                    ViewBag.thisFile = fileName.attachment_file_name;
                    ViewBag.thisId = keyId;
                }

                var viewedMessages = _libEntity.quest_lib.Where(x => x.q_id == keyId).FirstOrDefault();

                if (viewedMessages.viewed_mess == false)
                {
                    viewedMessages.viewed_mess = true;
                    _libEntity.SaveChanges();
                }

                var getLibAnswer = _askRepository.GetLibAnswer(keyId);

                return View(getLibAnswer);

            }

        }
        [HttpGet]
        public ActionResult GetQuestion(asklib _objRequest)
        {

            LibSecurity.IsLoggedIn = true;

            var getCatList = _adminRepository.GetCatList();

            _objRequest.GetCatList = getCatList.Select(x => new SelectListItem()

             {
                 Text = x.CatName,
                 Value = x.CatId.ToString()
             });

            ModelState.Clear();
            return View(_objRequest);

        }
        [HttpPost]
        public ActionResult UserInfoPost(asklib _objResponse)
        {
            var thisPost = _askRepository.AddAskLib(_objResponse);
            return View();
        }

        public ActionResult AskLibFeedback()
        {
            return View();
        }  
        public ViewResult SendEmail(mail _objModelMail)
        {        
            //this will fire off an email to the library folder. 
            //would really like to move this the repository but the lambdas and interface also exists with this bit of code. 10/12. 

            using (var _libEntity = new LibEntities())
            {
                int? id = _objModelMail.QuestId;

                quest_tb qt = _libEntity.quest_tb.FirstOrDefault(x => x.q_id == id);

                MailMessage mail = new MailMessage();

                SmtpClient smtpServer = new SmtpClient("smtp.ncu.edu");

                mail.From = new MailAddress(qt.email_address, qt.u_last_name + ", " + qt.u_first_name);
                mail.To.Add("library@ncu.edu");
                mail.Subject = "Feedback - Knowledge Base";
                mail.Body = "Feedback: " + _objModelMail.Comments + "\r QuestionID: " + id;

                smtpServer.Send(mail);

                return View(_objModelMail);
            }        
        }                      
        public ActionResult FileDownload(string id)
        {
            /*well good to know that I can't use this in the repository. 
            Need to do more research about conflict with type model admin and 
            and filecontentresult. Would really like to put this method in the 
            admin repository but at this point I am uncertain on how to proceed. 
            */

            using (var _libEntity = new LibEntities())
            {
                int keyId = int.Parse(id);

                var file = _libEntity.file_uploads.First(f => f.q_id == keyId);

                var fileRes = new FileContentResult(file.attachment_file.ToArray(), "application/octet-stream");

                fileRes.FileDownloadName = file.attachment_file_name;

                return fileRes;
            }

        }

    }

}

