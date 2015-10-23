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
        private LibEntities _libEntity = new LibEntities();
        
        public IEnumerable<home> GetAll()
        {
            throw new NotImplementedException();
        }

        public home GetById(int? id)
        {
            throw new NotImplementedException();
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

        public object Edit(home entity)
        {
            throw new NotImplementedException();
        }

        public object Add(home entity)
        {
            throw new NotImplementedException();
        }

        public object Delete(home entity)
        {
            throw new NotImplementedException();
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