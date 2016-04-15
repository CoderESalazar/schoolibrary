using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryMVC4.Models;
using LibraryMVC4.Entity;

namespace LibraryMVC4.Repository
{
    public class DirMessageRepository : IRepository<home>
    {
        public IEnumerable<home> GetAll()
        {
            using (var _libEntity = new LibEntities())
            {
                var getDirMessage = (from mess in _libEntity.letters_tb
                                     orderby mess.date_time descending
                                     select new home
                                     {
                                         EntryId = mess.entry_id,
                                         LetterTitle = mess.letter_title,
                                         Display = mess.display_letter_id,
                                         DateTime = mess.date_time
                                     }).ToList();

                return getDirMessage;
            }           
                        
        }

        public home GetById(int? id)
        {
            using (var _libEntity = new LibEntities())
            {
                var dirMessage = (from ltb in _libEntity.letters_tb
                                  where ltb.entry_id == id
                                  select new home
                                  {
                                      EntryId = ltb.entry_id,
                                      LetterTitle = ltb.letter_title,
                                      LetterContent = ltb.letter_content,
                                      Display = ltb.display_letter_id                                    

                                  }).SingleOrDefault();

                return dirMessage;
            }

        }

        public IEnumerable<home> List(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<home> GetList(string m, string p)
        {
            throw new NotImplementedException();
        }

        public home GetById(int id)
        {
            using (var _libEntity = new LibEntities())
            {
                var dirMessage = (from ltb in _libEntity.letters_tb
                                  where ltb.display_letter_id == true && ltb.entry_id == id
                                  select new home
                                  {
                                      EntryId = ltb.entry_id,
                                      LetterTitle = ltb.letter_title,
                                      LetterContent = ltb.letter_content

                                  }).SingleOrDefault();

                return dirMessage;
            }           

        }

        public object Edit(home entity)
        {
            bool result = false;
            using (var _libEntity = new LibEntities())
            {
                letters_tb ltb = _libEntity.letters_tb.FirstOrDefault(t => t.entry_id == entity.EntryId);

                ltb.letter_title = entity.LetterTitle;
                ltb.letter_content = entity.LetterContent;
                ltb.display_letter_id = entity.Display;
                ltb.date_time = DateTime.Now;

                _libEntity.SaveChanges();
                result = true;

            }
            return result;
        }

        public object Add(home entity)
        {
            bool result = false;
            using (var _libEntity = new LibEntities())
            {
                var ltb = new letters_tb
                {
                    letter_title = entity.LetterTitle,
                    letter_content = entity.LetterContent,
                    display_letter_id = false,
                    date_time = DateTime.Now
                };

                _libEntity.letters_tb.AddObject(ltb);
                _libEntity.SaveChanges();

            }

            return result;
        }

        public object Delete(home entity)
        {
            bool result = false;

            using (var _libEntity = new LibEntities())
            {
                var deleteResource = _libEntity.letters_tb.FirstOrDefault(t => t.entry_id == entity.EntryId);
                _libEntity.DeleteObject(deleteResource);
                _libEntity.SaveChanges();
                result = true;

            }
            return result;
        }
        public IEnumerable<home> GetSite(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<home> List(int id)
        {
            throw new NotImplementedException();
        }
    }
}