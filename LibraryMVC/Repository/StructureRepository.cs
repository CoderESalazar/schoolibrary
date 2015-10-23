using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryMVC4.Models;
using LibraryMVC4.Security;
using LibraryMVC4.Entity;
using Ncu.Logging.Logger;


namespace LibraryMVC4.Repository
{
    public class StructureRepository : IStructure<structure>
    {

        public IEnumerable<structure> GetLibraryPages()
        {

            using (var _ncuElrc = new LibEntities())
            {
                var getLibraryPgs = (from s in _ncuElrc.elrc_structure
                                     select new structure
                                     {
                                         HighId = s.high_id,
                                         Title = s.title_name,
                                         PageType = s.type_page,
                                         LinkData = s.link_data,
                                         ParentId = s.parent_id,
                                         DisplayOrder = s.display_order

                                     }).ToList();

                return getLibraryPgs;

            }
        }

        public object UpdateLibPage(structure entity)
        {

            int id = entity.HighId;

            LibEntities _ncuElrc = new LibEntities();

            bool result = false;

            elrc_structure update = _ncuElrc.elrc_structure.FirstOrDefault(e => e.high_id == id);

            try
            {
                if (update != null)
                {

                    update.title_name = entity.Title;
                    update.parent_id = entity.ParentId;
                    update.link_data = entity.LinkData;
                    update.display_order = entity.DisplayOrder;
                    update.type_page = entity.PageType;

                    _ncuElrc.SaveChanges();
                    result = true;

                }

            }
            catch (Exception e)
            {
                ExceptionLogger.Log(ExceptionLogger.SeverityLevels.fatal, e, "Next action is to re-throw this exception object");
                result = false;
            }
            finally
            {
                _ncuElrc.Connection.Close();
            }

            return result;
        }

        public object DeleteLibPage(int id)
        {

            using (var _ncuElrc = new LibEntities())
            {

                var delete = _ncuElrc.elrc_structure.FirstOrDefault(t => t.high_id == id);

                if (delete == null)
                {
                    return false;
                }
                else
                {
                    _ncuElrc.DeleteObject(delete);
                    _ncuElrc.SaveChanges();
                    return true;
                }
            }
        }
        public object StopChat(int id)
        {
            LibEntities _ncuElrc = new LibEntities();

            bool result = false;

            chat update = _ncuElrc.chat.FirstOrDefault(c => c.lib_id == id);

            try
            {
                if (update != null)
                {
                    update.end_time = DateTime.Now;
                    update.lib_chat = false;

                    _ncuElrc.SaveChanges();
                    result = true;
                }
            }
            catch (Exception e)
            {
                ExceptionLogger.Log(ExceptionLogger.SeverityLevels.fatal, e, "Next action is to re-throw this exception object");
                result = false;
            }
            finally
            {
                _ncuElrc.Connection.Close();
            }

            return result;
        }

        public object AddLibPage(structure entity)
        {
            LibEntities _ncuElrc = new LibEntities();
            bool result = false;

            try
            {
                var elrc_tb = new elrc_structure
                {
                    title_name = entity.Title,
                    parent_id = entity.ParentId,
                    link_data = entity.LinkData,
                    type_page = entity.PageType,
                    display_order = entity.DisplayOrder
                };

                _ncuElrc.elrc_structure.AddObject(elrc_tb);
                _ncuElrc.SaveChanges();

                result = true;
            }
            catch (Exception e)
            {
                ExceptionLogger.Log(ExceptionLogger.SeverityLevels.fatal, e, "Next action is to re-throw this exception object");
            }
            finally
            {
                _ncuElrc.Connection.Close();
            }
            return result;

        }

        public object StartChat()
        {
            LibEntities _ncuElrc = new LibEntities();
            bool result = false;            
           
            try
            {
                var chat = new chat
                {
                    user_id = LibSecurity.UserId,
                    start_time = DateTime.Now,
                    lib_chat = true
                };
                _ncuElrc.chat.AddObject(chat);
                _ncuElrc.SaveChanges();

                result = true;
            }
            catch (Exception e)
            {
                ExceptionLogger.Log(ExceptionLogger.SeverityLevels.fatal, e, "Next action is to re-throw this exception object");
            }
            finally
            {

                _ncuElrc.Connection.Close();
            }

            return result;

        }
        public IEnumerable<structure> GetChatList()
        {
            var _ncuElrc = new LibEntities();

            var getChatList = (from c in _ncuElrc.chat
                               join lp in _ncuElrc.lib_admin_people on c.user_id equals lp.lib_string_id
                               orderby c.lib_id descending
                               select new structure
                               {
                                   LibLastName = lp.lib_name,
                                   StartTime = c.start_time,
                                   EndTime = c.end_time,
                                   ChatActive = c.lib_chat

                               }).Take(20);

            _ncuElrc.Connection.Close();

            return getChatList;
            
        }
    }
}