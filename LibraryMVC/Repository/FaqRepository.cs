using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryMVC4.Models;
using LibraryMVC4.Entity;
using LibraryMVC4.Security;
using Ncu.Logging.Logger;
using LibraryMVC4.Utilities;

namespace LibraryMVC4.Repository
{
    public class FaqRepository : IFaq<admin>
    {

        public admin GetByFaq(int id)
        {
            using (var _libEntity = new LibEntities())
            {
                var getFaq = (from ql in _libEntity.quest_lib
                              join qt in _libEntity.quest_tb on ql.q_id equals qt.q_id
                              join qc in _libEntity.quest_cat on ql.lib_cat equals qc.cat_id
                              where ql.q_id == id
                              select new home
                              {
                                  LibrarianResponse = ql.lib_response,
                                  LibDateTime = qt.date_time,
                                  LibResponseEdit = ql.lib_q_edit,
                                  CatName = qc.cat_name,
                                  CatId = ql.lib_cat,
                                  QuestId = ql.q_id

                              }).FirstOrDefault();
                return getFaq;
             }
        }

        public object AddUserFeedback(string c, int d)
        {
            using (var _libEntity = new LibEntities())
            {
                FaqButtonChoice myButtonValue;
                Enum.TryParse(c, out myButtonValue);

                switch (myButtonValue)
                {
                    case FaqButtonChoice.Yes:

                        try
                        {

                            string b = "True";
                            var _questFdbk = new quest_fdbk

                            {
                                fdbk = b,
                                fdbk_user_id = LibSecurity.UserId,
                                q_id = d,
                                date_time = DateTime.Now

                            };

                            _libEntity.quest_fdbk.AddObject(_questFdbk);
                            _libEntity.SaveChanges();

                        }
                        catch (Exception exception)
                        {
                            ExceptionLogger.Log(ExceptionLogger.SeverityLevels.fatal, exception, "Next action is to re-throw this exception object");
                        }
                        break;
                    case FaqButtonChoice.No:

                        try
                        {

                            string b = "False";
                            var _questFdbk = new quest_fdbk

                            {
                                fdbk = b,
                                fdbk_user_id = LibSecurity.UserId,
                                q_id = d,
                                date_time = DateTime.Now

                            };

                            _libEntity.quest_fdbk.AddObject(_questFdbk);
                            _libEntity.SaveChanges();
                        }
                        catch (Exception exception)
                        {
                            ExceptionLogger.Log(ExceptionLogger.SeverityLevels.fatal, exception, "Next action is to re-throw this exception object");

                        }
                        break;
                }
                return null;
            }
        }
        public IEnumerable<admin> BrowseByCat(string id)
        {
            using (var _libEntity = new LibEntities())
            {
                var ids = int.Parse(id);
                var browseFaq = (from ql in _libEntity.quest_lib
                                 join qc in _libEntity.quest_cat on ql.lib_cat equals qc.cat_id
                                 where ql.lib_cat == ids && ql.q_status == "Submitted to KB" && ql.cat_id == true
                                 orderby ql.lib_date_time descending
                                 select new home
                                 {
                                     QuestId = ql.q_id,
                                     LibResponseEdit = ql.lib_q_edit,
                                     CatName = qc.cat_name

                                 }).ToList();

                return browseFaq;
            }
        }
    }
}