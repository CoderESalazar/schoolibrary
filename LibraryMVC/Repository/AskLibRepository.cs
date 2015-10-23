using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryMVC4.Security;
using LibraryMVC4.Entity;
using LibraryMVC4.Models;
using LibraryMVC4.Repository;
using System.Net.Mail;

namespace LibraryMVC4.Repository
{
    public class AskLibRepository : IAskLib<asklib>
    {
        
        public IEnumerable<asklib> GetAllUserQs()
        {
            using (var _libEntity = new LibEntities())
            {

                var libQuest = (from questTb in _libEntity.quest_tb
                                join questLib in _libEntity.quest_lib on questTb.q_id equals questLib.q_id
                                where questTb.q_type == null
                                    //&& questTb.user_id == "7304205318"
                                && questTb.user_id == LibSecurity.UserId
                                && questLib.q_status.Contains("Submitted to KB")
                                orderby questTb.date_time descending
                                select new asklib
                                {
                                    QuestId = questTb.q_id,
                                    PatronFirstName = questTb.u_first_name,
                                    PatronLastName = questTb.u_last_name,
                                    PatronId = questTb.user_id,
                                    DateTime = questTb.date_time,
                                    QuestDetail = questTb.q_detail,
                                    LibrarianResponse = questLib.lib_response,
                                    ViewedMess = questLib.viewed_mess

                                }).ToList();

                return libQuest;

            }
        }

        public asklib GetLibAnswer(int id)
        {

            using (var _libEntity = new LibEntities())
            {
                var getLibAns = (from qLib in _libEntity.quest_lib
                                 join qTb in _libEntity.quest_tb on qLib.q_id equals qTb.q_id
                                 join fTb in _libEntity.file_uploads on qTb.q_id equals fTb.q_id
                                 where qLib.q_id == id
                                 select new asklib
                                 {
                                     QuestId = qLib.q_id,
                                     LibrarianResponse = qLib.lib_response,
                                     QuestDetail = qTb.q_detail,
                                     FileName = fTb.attachment_file_name

                                 }).FirstOrDefault();

                if (getLibAns == null)
                {

                    var getLibAnsT = (from qLib in _libEntity.quest_lib
                                      join qTb in _libEntity.quest_tb on qLib.q_id equals qTb.q_id
                                      where qLib.q_id == id
                                      select new asklib
                                      {
                                          QuestId = qTb.q_id,
                                          LibrarianResponse = qLib.lib_response,
                                          QuestDetail = qTb.q_detail,

                                      }).FirstOrDefault();

                    return getLibAnsT;
                }

                return getLibAns;

            }
        }
        public object AddAskLib(asklib entity)
        {

            using (var _libEntity = new LibEntities())
            {
                bool result = false;
                try
                {
                    UserRepository myUserRepository = new UserRepository();
                    var t = myUserRepository.GetUserInfo();

                    var UserInfo = new quest_tb

                    {
                        user_id = t.PatronId,
                        u_first_name = t.PatronFirstName,
                        u_last_name = t.PatronLastName,
                        deg_prog = t.DegProg,
                        email_address = t.PatronEmail,
                        q_detail = entity.QuestDetail,
                        cat_desc = entity.CatId,
                        course_num = entity.CourseNum,
                        assign_num = entity.AssignNum,
                        date_time = DateTime.Now

                    };

                    _libEntity.quest_tb.AddObject(UserInfo);
                    _libEntity.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;

                }

                return result;
            }

        }

    }
}