using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVC4.Repository;
using LibraryMVC4.Models;
using LibraryMVC4.Entity;
using PagedList;
using System.Web.UI;
using System.Data.Objects;

namespace LibraryMVC4.Controllers
{
    public class DissController : Controller
    {
        private ncuEntities _ncuEntities = new ncuEntities();
        private IDiss<diss> _dissRepository;
        private IAdmin<admin> _adminRepository;

        public DissController()
        {
            _dissRepository = new DissRepository();
            _adminRepository = new AdminRepository();
        }

        public DissController(IDiss<diss> dissRepository, IAdmin<admin> adminRepository)
        {
            _dissRepository = dissRepository;
            _adminRepository = adminRepository;
        }

        public ActionResult Index(diss model)
        {
            return View(_dissRepository.GetSchoolPrograms());
        }

        [OutputCache(Duration = 30, Location = OutputCacheLocation.ServerAndClient, NoStore = true)]
        public ActionResult GetDept(string id, string sortOrder, int? page)
        {
            //used to keep sort order while paging
            ViewBag.CurrentSort = sortOrder;

            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "date_asc" : "";
            ViewBag.DegreeSortParm = sortOrder == "Degree" ? "degree_desc" : "Degree";

            var dissList = _dissRepository.GetDissByProg(id);


            switch (sortOrder)
            {

                case "date_asc":

                    dissList = dissList.OrderBy(d => d.statDate);
                    break;

                case "Degree":

                    dissList = dissList.OrderBy(d => d.degProgCode);
                    break;

                case "degree_desc":

                    dissList = dissList.OrderByDescending(d => d.degProgCode);
                    break;

                default:

                    dissList = dissList.OrderByDescending(d => d.statDate);
                    break;

            }

            int pageSize = 20;
            int pageNumber = (page ?? 1);


            return View(dissList.ToPagedList(pageNumber, pageSize));

        }
        [Authorize()]
        public ActionResult FileDownload(string id)
        {
            var keyId = int.Parse(id);

            var dissFile = _ncuEntities.dissertation_checklist.First(f => f.dissertation_id == keyId);

            var fileRes = new FileContentResult(dissFile.dissertation_file.ToArray(), "application/octet-stream");
            fileRes.FileDownloadName = dissFile.dissertation_file_name;

            return fileRes;

        }
        public ActionResult GetAbstract(string id)
        {
            var keyId = int.Parse(id);

            //Add a ViewBag and id to view so we can set up a link back from chair to abstract. 
            var dissAbstract = _dissRepository.GetAbstract(keyId);
            return View(dissAbstract);
        }
        public ActionResult GoSearch(diss model)
        {

            if (model.SearchVariables != null)
            {

                String GetDropDownValue = model.DropDrownMenuVar;
                String GetSearchText = model.SearchVariables;

                var GetSearch = _dissRepository.GetDissSearch(GetDropDownValue, GetSearchText);

                //return Content("This is the content " + GetSearch);
                return View(GetSearch);
            }

            else
            {
                return Redirect("/diss/index");
            }

        }
        public ActionResult GetChair(string chairId)
        {
            var chairList = _dissRepository.GetChairName(chairId);
            return View(chairList);

        }
        public ActionResult GetSearchPartial()
        {
            diss model = new diss();

            List<SelectListItem> dissList = new List<SelectListItem>();

            dissList.Add(new SelectListItem()
            {
                Value = "1",
                Text = "Title"
            });
            dissList.Add(new SelectListItem()
            {
                Value = "2",
                Text = "Author"
            });
            dissList.Add(new SelectListItem()
            {
                Value = "3",
                Text = "Abstract"

            });

            model.DissList = new SelectList(dissList, "Value", "Text");
            //diss _mySelectList = new diss();
            return PartialView("DissSearch", model);

        }

    }
}
