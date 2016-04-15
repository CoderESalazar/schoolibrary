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
    public class DirMessageController : Controller
    {

        private LibEntities _libEntity = new LibEntities();
        private IRepository<home> _dirMessageRepository;

        public DirMessageController()
        {
            _dirMessageRepository = new DirMessageRepository();
        }

        public DirMessageController(IRepository<home> repository)
        {
            _dirMessageRepository = repository;
        }

        public ActionResult Index(int entryId)
        {
            var getDirMess = _dirMessageRepository.GetById(entryId);
            return View(getDirMess);
        }

        public ViewResult Admin()
        {
            var getAdmin = _dirMessageRepository.GetAll();
            return View(getAdmin);
        }

        public ViewResult Edit(int? id)
        {
            var getLetter = _dirMessageRepository.GetById(id);

            return View("EditLetter", getLetter);
        }

        public ViewResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public ActionResult AddPost([Bind(Include = "LetterTitle,LetterContent")] home _objAddItems)
        {
            var add = _dirMessageRepository.Add(_objAddItems);
            return Redirect("Admin" + "/#addsuccess");
        }

        [HttpPost]
        public ActionResult EditPost([Bind(Include = "EntryId,LetterTitle,Display,LetterContent")] home _objEditItems)
        {
            var postLetter = _dirMessageRepository.Edit(_objEditItems);
            return RedirectToAction("Admin" + "/#editsuccess");
        }

        [HttpPost]
        public ActionResult Delete([Bind(Include = "EntryId")] home _deleteItems)
        {
            var deleteMessage = _dirMessageRepository.Delete(_deleteItems);

            return RedirectToAction("Admin" + "/#deletesuccess");

        }

    }
}
