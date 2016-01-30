using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryMVC4.Entity;
using LibraryMVC4.Models;
using LibraryMVC4.Security;
using Ncu.Logging.Logger;
using System.Web.Mvc;
using LibraryMVC4.Utilities;
using System.Text.RegularExpressions;


namespace LibraryMVC4.Repository
{
    public class SearchRepository : ISearch<admin>
    {    
        public IEnumerable<admin> GetUListNames(string id)
        {

            using (var _libEntity = new LibEntities()) 
            { 
                var getUListNames = (from qt in _libEntity.quest_tb
                                     join ql in _libEntity.quest_lib on qt.q_id equals ql.q_id
                                     join lap in _libEntity.lib_admin_people on ql.lib_userid equals lap.lib_string_id     
                                     where qt.user_id == id
                                     orderby ql.lib_date_time descending
                                     select new admin
                                     {
                                         PatronId = qt.user_id,
                                         QuestId = qt.q_id,
                                         DateTime = ql.lib_date_time,
                                         QuestStatus = ql.q_status,
                                         QuestType = qt.q_type,
                                         PatronName = qt.u_first_name + " " + qt.u_last_name,
                                         CourseNum = qt.course_num,
                                         LibLastName = lap.lib_name,
                                         CatName = ql.new_cat,
                                         EmailSent = ql.email_sent

                                     }).ToList();

                return getUListNames;
            }

        }

        public IEnumerable<admin> SearchByKeyWords(string a, string b, string c)
        {

            SearchDropDown searchDrop;
            Enum.TryParse(c, out searchDrop);

            //throw new NotImplementedException();
            //int s = Convert.ToInt32(c);
            using (var _libEntity = new LibEntities())
            {
                switch (searchDrop)
                {
                    case SearchDropDown.And:

                        if (a.Length > 0 && b.Length > 0)
                        {

                            var getSearch = (from qt in _libEntity.quest_tb
                                             join ql in _libEntity.quest_lib on qt.q_id equals ql.q_id
                                             join lap in _libEntity.lib_admin_people on ql.lib_userid equals lap.lib_string_id
                                             where ql.lib_response.Contains(a) && ql.lib_response.Contains(b) ||
                                             qt.q_detail.Contains(a) && qt.lib_response.Contains(b)
                                             orderby ql.lib_date_time descending
                                             select new admin
                                             {
                                                 PatronId = qt.user_id,
                                                 QuestId = qt.q_id,
                                                 DateTime = ql.lib_date_time,
                                                 QuestStatus = ql.q_status,
                                                 QuestType = qt.q_type,
                                                 PatronName = qt.u_first_name + " " + qt.u_last_name,
                                                 CourseNum = qt.course_num,
                                                 LibLastName = lap.lib_name,
                                                 CatName = ql.new_cat

                                             }).ToList();

                            return getSearch;

                        }
                        else if (a.Length > 0 && b.Length == 0)
                        {
                            //string str = Regex.Replace(a, @"[^\w\.@-]", "");

                            var getSearch = (from qt in _libEntity.quest_tb
                                             join ql in _libEntity.quest_lib on qt.q_id equals ql.q_id
                                             join lap in _libEntity.lib_admin_people on ql.lib_userid equals lap.lib_string_id
                                             where ql.lib_response.Contains(a) || qt.q_detail.Contains(a) || qt.lib_response.Contains(a)
                                             orderby ql.lib_date_time descending
                                             select new admin
                                             {
                                                 PatronId = qt.user_id,
                                                 QuestId = qt.q_id,
                                                 DateTime = ql.lib_date_time,
                                                 QuestStatus = ql.q_status,
                                                 QuestType = qt.q_type,
                                                 PatronName = qt.u_first_name + " " + qt.u_last_name,
                                                 CourseNum = qt.course_num,
                                                 LibLastName = lap.lib_name,
                                                 CatName = ql.new_cat

                                             }).ToList();

                            return getSearch;
                        }

                        break;

                    case SearchDropDown.Or:

                        try
                        {

                            var getOrSearch = (from ql in _libEntity.quest_lib
                                               join qt in _libEntity.quest_tb on ql.q_id equals qt.q_id
                                               join lap in _libEntity.lib_admin_people on ql.lib_userid equals lap.lib_string_id
                                               where ql.lib_response.Contains(a) ||
                                               ql.lib_response.Contains(b) ||
                                               qt.q_detail.Contains(a) ||
                                               qt.q_detail.Contains(b)
                                               orderby ql.lib_date_time descending
                                               select new admin
                                               {
                                                   PatronId = qt.user_id,
                                                   QuestId = qt.q_id,
                                                   DateTime = ql.lib_date_time,
                                                   QuestStatus = ql.q_status,
                                                   QuestType = qt.q_type,
                                                   PatronName = qt.u_first_name + " " + qt.u_last_name,
                                                   CourseNum = qt.course_num,
                                                   LibLastName = lap.lib_name,
                                                   CatName = ql.new_cat

                                               }).ToList();

                            return getOrSearch;

                        }
                        catch
                        {

                        }

                        break;

                    case SearchDropDown.Not:

                        try
                        {
                            var getNotSearch = (from ql in _libEntity.quest_lib
                                                join qt in _libEntity.quest_tb on ql.q_id equals qt.q_id
                                                join lap in _libEntity.lib_admin_people on ql.lib_userid equals lap.lib_string_id
                                                where !qt.lib_response.Contains(b) && ql.lib_response.Contains(a) ||
                                                !qt.q_detail.Contains(b) && qt.q_detail.Contains(a)
                                                orderby ql.lib_date_time descending
                                                select new admin
                                                {
                                                    PatronId = qt.user_id,
                                                    QuestId = qt.q_id,
                                                    DateTime = ql.lib_date_time,
                                                    QuestStatus = ql.q_status,
                                                    QuestType = qt.q_type,
                                                    PatronName = qt.u_first_name + " " + qt.u_last_name,
                                                    CourseNum = qt.course_num,
                                                    LibLastName = lap.lib_name,
                                                    CatName = ql.new_cat

                                                }).ToList();


                            return getNotSearch;

                        }
                        catch
                        {

                        }

                        break;

                }
                return null;
            }
        }

        public admin GetByQId(int id)
        {           

            using (var _libEntity = new LibEntities())
            {

                try {

                    var getLibQId = (from g in _libEntity.GetLibQId(id)
                                     select new admin
                                     {
                                         PatronId = g.user_id,
                                         QuestId = g.q_id,
                                         DateTime = g.lib_date_time,
                                         QuestStatus = g.q_status,
                                         QuestType = g.q_type,
                                         PatronName = g.PatronName,
                                         CourseNum = g.course_num,
                                         LibLastName = g.last_name,
                                         CatName = g.new_cat,
                                         EmailSent = g.email_sent

                                     }).FirstOrDefault();


                    return getLibQId;

                    }

                catch(ArgumentNullException ex)
                {
                    throw ex;
                }

            }
        }
        public IEnumerable<admin> GetCourse(string id)
        {
            string myString = id.Trim();

            using (var _libEntity = new LibEntities())
            {
                var getCourse = (from ql in _libEntity.quest_lib
                                 join qt in _libEntity.quest_tb
                                 on ql.q_id equals qt.q_id
                                 join lap in _libEntity.lib_admin_people on ql.lib_userid equals lap.lib_string_id
                                 where qt.course_num.Contains(myString)
                                 orderby ql.lib_date_time descending
                                 select new admin
                                 {
                                     PatronId = qt.user_id,
                                     QuestId = qt.q_id,
                                     DateTime = ql.lib_date_time,
                                     QuestStatus = ql.q_status,
                                     QuestType = qt.q_type,
                                     PatronName = qt.u_first_name + " " + qt.u_last_name,
                                     CourseNum = qt.course_num,
                                     LibLastName = lap.lib_name,
                                     CatName = ql.new_cat

                                 }).ToList();

                return getCourse;

            }
        }

    }
}