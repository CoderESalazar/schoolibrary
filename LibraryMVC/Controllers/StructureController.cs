using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVC4.Entity;
using LibraryMVC4.Models;
using LibraryMVC4.Repository;
using LibraryMVC4.Security;
using LibraryMVC4.Controllers.Attributes;
using System.Web.Helpers;

namespace LibraryMVC4.Controllers
{

    [LibraryAdmin]
    public class StructureController : Controller
    {
        private IStructure<structure> _structureRepository;

        public StructureController()
        {
            _structureRepository = new StructureRepository();

        }
        public StructureController(IStructure<structure> repository)
        {
            _structureRepository = repository;
        }
        public ActionResult Index()
        {
            var getLibraryPages = _structureRepository.GetLibraryPages();

            return View(getLibraryPages);
        }

        public ActionResult GetAlerts()
        {
            var getAlerts = _structureRepository.GetRecentAlerts();
            return View(getAlerts);

        }
        [HttpPost]
        public JsonResult UpdateLibraryAdmin(structure model)
        {

            var updateLibPage = _structureRepository.UpdateLibPage(model);

            if ((bool)updateLibPage == true)
            {
                string message = "Page Updated!";
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            else
            {
                string message = "Failure!";
                return Json(message, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpDelete]
        public JsonResult DeleteLibPage(structure model)
        {
            int id = model.HighId;

            var deleteLibPage = _structureRepository.DeleteLibPage(id);

            if ((bool)deleteLibPage == true)
            {
                string message = "Page Deleted!";
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            else
            {
                string message = "Failure!";
                return Json(message, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult AddPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddLibPage(structure _objItems)
        {

            var addLibPage = _structureRepository.AddLibPage(_objItems);

            return Redirect("/structure/index");
        }
        public ActionResult Chat()
        {
            var getChatList = _structureRepository.GetChatList();

            using (var _ncuElrc = new LibEntities())
            {
                var chatId = _ncuElrc.chat.FirstOrDefault(c => c.lib_chat == true);

                if (chatId != null)
                {
                    ViewBag.LibId = chatId.lib_id;
                }
            }
            return View(getChatList);

        }
        [HttpPost]
        public ActionResult ChatStart()
        {
            LibEntities _ncuElrc = new LibEntities();
            var checkChatStart = _ncuElrc.chat.FirstOrDefault(c => c.lib_chat == true);

            if (checkChatStart == null)
            {
                var chatStart = _structureRepository.StartChat();
            }
            else
            {
                return Content("Sorry, but there's an active chat session. Please end the current session.");
            }

            _ncuElrc.Connection.Close();

            return Redirect("/structure/chat");

        }
        [HttpPost]
        public ActionResult ChatEnd(int id)
        {
            var chatEnd = _structureRepository.StopChat(id);

            return Redirect("/structure/chat");

        }
        public ActionResult AddAlert()
        {
            return View();

        }
        public ActionResult EditAlert(int id)
        {
            var editAlert = _structureRepository.EditAlert(id);

            return View(editAlert);
        }

        [HttpPost]
        public ActionResult PostAlert(structure _addAlertObjs)
        {
            var addAlert = _structureRepository.AddAlert(_addAlertObjs);

            if ((bool)addAlert == true)
            {
                string msg = "Alert Added";

                return Redirect("/structure/GetAlerts/" + msg);
            }

            return Redirect("/structure/GetAlerts/" + "Error");

        }

        [HttpPost]
        public ActionResult PostEditAlert(structure _editAlertObjs)
        {
            var postEditAlert = _structureRepository.EditPostAlert(_editAlertObjs);

            if((bool)postEditAlert == true)
            {
                string msg = "Alert Edited";            
                return Redirect("/structure/GetAlerts/" + msg);
            }

            return Redirect("/structure/GetAlerts/" + "Error");

        }
    }
}
