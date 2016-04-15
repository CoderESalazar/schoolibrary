using System;
using System.Collections.Generic;
using System.Linq;
using LibraryMVC4.Models;
using LibraryMVC4.Entity;
using LibraryMVC4.Security;
using System.Web.Mvc;

namespace LibraryMVC4.Repository
{
    public class HomeRepository : IHome<home>
    {        
        public IEnumerable<home> GetBlogPosts()
        {
            using (var _libEntity = new LibEntities())
            {
                var getPosts = (from blog in _libEntity.blog_tb
                                orderby blog.EnteredDateTime descending
                                select new home
                                {
                                    BlogHeaderId = blog.BlogId,
                                    BlogHeader = blog.BlogHeader,
                                    BlobBlob = blog.BlogText,
                                    DateTime = blog.EnteredDateTime

                                }).Take(3).ToList();

                return getPosts;
            }
       
        }
        //believe this dropdown menu is now can be replaced by catlist. 
        public IEnumerable<home> GetFAQList()
        {
            using (var _libEntity = new LibEntities())
            {

                var libFaq = (from qc in _libEntity.quest_cat
                              join ql in _libEntity.quest_lib on qc.cat_id equals ql.lib_cat
                              where ql.q_status == "Submitted to KB" && ql.cat_id == true
                              orderby qc.cat_name
                              select new home
                              {
                                  CatId = qc.cat_id,
                                  CatName = qc.cat_name

                              }).Distinct().ToList();

                return libFaq;

            }
        }

        public home GetAlert()
        {

            using (var _libEntity = new LibEntities())
            {
                var alertMess = (from alert in _libEntity.alert_box
                                 where alert.alert_bit == true
                                 select new home
                                 {
                                     AlertMess = alert.alert_mess,
                                     AlertTitle = alert.alert_title,
                                     AlertBit = alert.alert_bit

                                 }).FirstOrDefault();

                return alertMess;
            }

        }

        public home ResourceOfMonth(int id)
        {
            using (var _libEntity = new LibEntities())
            {
                var resMonth = (from rom in _libEntity.resources_tb
                                where rom.display_resource_id == true
                                select new home
                                {
                                    ResourceTitle = rom.resource_title,
                                    REntryId = rom.entry_id

                                }).FirstOrDefault();
                return resMonth;

            }
        }

        public object AddUserPost(home entity)
        {
            LibEntities _libEntity = new LibEntities();
            bool result = false;
            try
            {
                UserRepository myUserInfo = new UserRepository();
                var t = myUserInfo.GetUserInfo();
                var feedBackPost = new feed_back

                {
                    u_first_name = t.PatronFirstName,
                    u_last_name = t.PatronLastName,
                    date_time = DateTime.Now,
                    deg_prog = t.DegProg,
                    email_address = t.PatronEmail,
                    user_id = t.PatronId,
                    notes_comments = entity.Comments,
                    u_name = t.PatronFirstName + " " + t.PatronLastName

                };

                _libEntity.feed_back.AddObject(feedBackPost);
                _libEntity.SaveChanges();

            }
            catch (Exception ex)
            {
                return ex.Message;

            }
            finally
            {
                _libEntity.Connection.Close();
            }

            return result; 
        }

        public object AddResoureofMonth(home entity)
        {
            throw new NotImplementedException();
        }


        public home GetChat()
        {
            using (var _libEntity = new LibEntities())
            {
                var _bool = (from c in _libEntity.chat
                             where c.lib_chat == true
                             select new home
                             {
                                 LibChat = c.lib_chat
                             }).FirstOrDefault();

                return _bool;
            }
            
        }


        public home GetDirMessage()
        {
            using (var _libEntity = new LibEntities())
            {

                var dirMessage = (from ltb in _libEntity.letters_tb
                                  where ltb.display_letter_id == true
                                  select new home
                                  {
                                      EntryId = ltb.entry_id,
                                      LetterTitle = ltb.letter_title
                                  }).FirstOrDefault();

                return dirMessage;

            }
        }
        public IEnumerable<home> SumResourceMonth(string id)
        {

            using (var _libEntity = new LibEntities())
            {

                int keyId = Convert.ToInt32(id);
                var resMonth = (from rom in _libEntity.resources_tb
                                join fdbk in _libEntity.resources_tb_fdbk
                                on rom.entry_id equals fdbk.entry_id into joined
                                where rom.entry_id == keyId
                                from j in joined.DefaultIfEmpty()
                                select new home
                                {
                                    ResourceTitle = rom.resource_title,
                                    REntryId = rom.entry_id,
                                    ResourceContent = rom.resource_content,
                                    Ratings = j.sel_radio,

                                }).ToList();

                return resMonth;

            }
        }

        public home ResourceOfMonth()
        {
            using (var _libEntity = new LibEntities())
            {
                var resMonth = (from rom in _libEntity.resources_tb
                                where rom.display_resource_id == true
                                select new home
                                {
                                    ResourceTitle = rom.resource_title,
                                    REntryId = rom.entry_id

                                }).FirstOrDefault();
                return resMonth;
            }        
        }


        public object AddRadioId(home entity, int id)
        {
            LibEntities _libEntity = new LibEntities();
            bool result = false;
            int _selectRadioItem = Convert.ToInt32(entity.SelectRadioItem);
            try
            {
                var RadioAdd = new resources_tb_fdbk
                {
                    entry_id = id,
                    sel_radio = _selectRadioItem,
                    res_fdbk = entity.Comments,
                    user_id = LibSecurity.UserId

                };

                _libEntity.resources_tb_fdbk.AddObject(RadioAdd);
                _libEntity.SaveChanges();
                result = true;
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                _libEntity.Connection.Close();
            }
            return result;
        }

        public JsonResult FindFaqs(string search, int results)
        {
            using (var _libEntity = new LibEntities())
            {
                var result = new JsonResult();

                result.Data = (from s in _libEntity.quest_lib
                              where s.lib_q_edit.ToLower().Contains(search.ToLower())
                              && s.q_status == "Submitted to KB"
                              && s.cat_id != false
                              select s).Distinct().Take(results).ToList();

                return result;
            }
        }
    }
}