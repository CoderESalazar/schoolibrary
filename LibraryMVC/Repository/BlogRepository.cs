using LibraryMVC4.Models;
using System;
using System.Collections.Generic;
using LibraryMVC4.Entity;
using System.Linq;
using System.Web;

namespace LibraryMVC4.Repository
{
    public class BlogRepository : IRepository<blog>
    {
        public object Add(blog entity)
        {
            bool result = false;

            using (var _libEntity = new LibEntities())
            {
                var blogTb = new blog_tb
                {
                    BlogHeader = entity.BlogHeader,
                    BlogText = entity.BlogText,
                    EnteredDateTime = DateTime.Now

                };

                _libEntity.blog_tb.AddObject(blogTb);
                _libEntity.SaveChanges();

                result = true;
            }

            return result;
        }

        public object Delete(blog entity)
        {
            bool result = false;

            using (var _libEntity = new LibEntities())
            {
                var postTb = _libEntity.blog_tb.FirstOrDefault(t => t.BlogId == entity.BlogId);

                if (postTb != null)
                {
                    _libEntity.DeleteObject(postTb);
                    _libEntity.SaveChanges();
                    return true;
                }

            }
            return result;
        }

        public object Edit(blog entity)
        {
            bool result = false;

            using (var _libEntity = new LibEntities())
            {
                blog_tb bt = _libEntity.blog_tb.FirstOrDefault(t => t.BlogId == entity.BlogId);

                if (bt != null)
                {
                    bt.BlogHeader = entity.BlogHeader;
                    bt.BlogText = entity.BlogText;
                    bt.EnteredDateTime = DateTime.Now;

                    _libEntity.SaveChanges();
                    result = true;
                }

                return result;
            }
        }

        public IEnumerable<blog> GetAll()
        {
            using (var _libEntity = new LibEntities())
            {
                var getPosts = (from blog in _libEntity.blog_tb
                                orderby blog.EnteredDateTime descending
                                select new blog
                                {
                                    BlogId = blog.BlogId,
                                    BlogHeader = blog.BlogHeader,
                                    BlogText = blog.BlogText,
                                    DateTime = blog.EnteredDateTime

                                }).ToList();
                
                return getPosts;
            }
        }

        public blog GetById(int id)
        {
            using (var _libEntity = new LibEntities())
            {
                var editPost = (from post in _libEntity.blog_tb
                                where post.BlogId == id
                                select new blog
                                {
                                    BlogId = post.BlogId,
                                    BlogHeader = post.BlogHeader,
                                    BlogText = post.BlogText

                                }).FirstOrDefault();

                return editPost;

            }
        }

        public blog GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<blog> GetSite(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<blog> List(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<blog> List(int id)
        {
            throw new NotImplementedException();
        }
    }
}