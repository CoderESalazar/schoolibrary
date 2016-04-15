using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVC4.Models;
using LibraryMVC4.Repository;

namespace LibraryMVC4.Controllers
{
    public class BlogController : Controller
    {
        private IRepository<blog> _repo;

        public BlogController()
        {
            _repo = new BlogRepository();
        }

        public BlogController(IRepository<blog> repository)
        {
            _repo = repository;

        }
        // GET: Blog
        public ActionResult Index()
        {
            var getBlogPosts = _repo.GetAll();

            return View(getBlogPosts);
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        public ActionResult Create(blog _objCreateItems)
        {
            try
            {
                var createNewPost = _repo.Add(_objCreateItems);

                return RedirectToAction("Index/" + "#PostHasBeenAdded");
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        // GET: Blog/Edit/5
        public ActionResult EditPost(int id)
        {
            var editPost = _repo.GetById(id);
            
            return View(editPost);

        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(blog _blogItems)
        {
            try
            {
                var postBlogItems = _repo.Edit(_blogItems);

                return RedirectToAction("Index/" + "#PostHasBeenEdited");
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Blog/Delete/5
        [HttpPost]
        public ActionResult Delete(blog _deletePostItem)
        {
            try
            {
                var deletePostItem = _repo.Delete(_deletePostItem);

                return RedirectToAction("Index/" + "#PostHasBeenDeleted");
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
