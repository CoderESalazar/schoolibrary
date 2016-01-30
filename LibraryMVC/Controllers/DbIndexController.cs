using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVC4.Repository;
using LibraryMVC4.Models;
using LibraryMVC4.Security;
using LibraryMVC4.Controllers.Attributes;

namespace LibraryMVC4.Controllers
{
    [LibraryAdmin]
    public class DbIndexController : Controller
    {
        //
        // GET: /DbIndex/
   
        private IRepository<dbindex> _repository;

        public DbIndexController()
        {
            _repository = new DbIndexRepository();
        }

        public DbIndexController(IRepository<dbindex> repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            var getDbList = _repository.GetAll();

            return View(getDbList);
        }
        public ActionResult Edit(int id)
        {
            var editDB = _repository.GetById(id);

            return View(editDB);
        }
        public ActionResult AddDb()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PostDb(dbindex _objDbEdit)
        {
            var postDb = _repository.Edit(_objDbEdit);

            if ((bool)postDb == true)
            {
                string msg = "Success";
                return Redirect("/DbIndex/Index/" + msg);
            }
            else
            {
                string msg = "Failure";
                return Redirect("/DbIndex/Index/" + msg);
            }
        }
        [HttpPost]
        public ActionResult AddDb(dbindex _objDbAdd)
        {
            var addDb = _repository.Add(_objDbAdd);

            if ((bool)addDb == true)
            {
                string msg = "Db Added";
                return Redirect("/DbIndex/Index/" + msg);
            }

            return Redirect("/DbIndex/Index/" + "Error");
        }
        [HttpPost]
        public ActionResult DeleteDb(dbindex _objDelete)
        {
            var deleteDb = _repository.Delete(_objDelete);

            return Redirect("/DbIndex/Index/" + "Db_Deleted");
        }

        public ActionResult DbDropDown(dbindex _listDbs)
        {
            var getDbDropDown = _repository.GetAll();


            //string a = "a";
            //string b = "b";

            //var getGenericTest = _repository.GetList(ref a, ref b);

            _listDbs.GetDbDrop = getDbDropDown.Select(d => new SelectListItem()
            {
                Text = d.dbTitle,
                Value = d.dbKeyId.ToString()
            });

            return PartialView("_dbDropDown", _listDbs);
        }
     }
}
