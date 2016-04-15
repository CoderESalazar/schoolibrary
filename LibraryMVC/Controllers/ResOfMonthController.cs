using LibraryMVC4.Controllers.Attributes;
using LibraryMVC4.Models;
using LibraryMVC4.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMVC4.Controllers
{
    [LibraryAdmin]
    public class ResOfMonthController : Controller
    {
        private IRepository<res> _repository;
        
        public ResOfMonthController()
        {
            _repository = new ResOfMonthRepository();
        }                

        public ResOfMonthController(IRepository<res> repository)
        {
            _repository = repository;
        }

        public ViewResult Index()
        {
            var getResMonth = _repository.GetAll();
            return View("Index", getResMonth);
        }       

        public ViewResult Add()
        {
            return View("Add");
        }
       
        [HttpPost]
        public ActionResult Add([Bind(Include = "ResourceTitle,ResourceText")] res _objAdd)
        {           
            var add = _repository.Add(_objAdd);
            return RedirectToAction("Index" + "/#addsuccess");        
        }       

        public ViewResult Edit(int id)
        {
            var edit = _repository.GetById(id);
            return View("Edit", edit);
        }       

        [HttpPost]
        public ActionResult Edit([Bind(Include = "EntryId,ResourceTitle,ResourceText,Display")] res _objectItems)
        {            
            var edit = _repository.Edit(_objectItems);
            return RedirectToAction("Index" + "/#editsuccess");           
        }

        [HttpPost]
        public ActionResult Delete([Bind(Include = "EntryId")] res _objDeleteItem)
        {           
            var deleteItem = _repository.Delete(_objDeleteItem);
            return RedirectToAction("Index" + "/#deletesuccess");
         }
    }
}
