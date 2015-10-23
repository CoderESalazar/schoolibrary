using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryMVC4.Models;
using LibraryMVC4.Entity;
using System.Text.RegularExpressions;
using LibraryMVC4.Utilities;
using Ncu.Logging.Logger;
using Ncu.Common.Utilities.Enums;


namespace LibraryMVC4.Repository
{
    public class DissRepository : IDiss<diss>
    { 
        public IEnumerable<diss> GetSchoolPrograms()
        {
            //20 = PHD BA
            //22 = PHD PSY
            //31 = EDD
            //34 = PHD MFT
            //8 = Technology

            using (var _libEntity = new LibEntities())
            {
                var dissMenu = (from p in _libEntity.GetSchoolNames()
                                select new diss
                                {
                                    DeptName = p.department_name,
                                    DeptId = p.department_id
                                }).ToList();

                return dissMenu;
            }

        }

        public IEnumerable<diss> GetDissByProg(string id)
        {
            //cast the int id to an enum for switch processing. 
            //SchoolPrograms schoolProg = (SchoolPrograms)Enum.ToObject(typeof(SchoolPrograms), id);

            //Schools school = (Schools)Enum.ToObject(typeof(Schools), id);
            //private ncuEntities _ncuEntities = new ncuEntities();

            Schools school;
            Enum.TryParse(id, true, out school);

            using (var _ncuEntities = new ncuEntities())
            {

                switch (school)
                {
                    case Schools.Bus:

                        try
                        {
                            var degProgBid = new int[] { 17, 20 };
                            var degProgBStat = new string[] { "Graduate", "Pending Grad" };

                            var BDisList = (from dTb in _ncuEntities.dissertation_checklist_report
                                            where dTb.dissertation_abstract_display == true
                                            && dTb.dissertation_abstract != ""
                                            && dTb.i899a_title_of_diss != ""
                                            && degProgBid.Contains((int)dTb.degree_program_id)
                                            && degProgBStat.Contains((string)dTb.degree_program_status)
                                            //orderby dTb.stat_date descending
                                            select new diss
                                            {
                                                fLearnerName = dTb.learner_first_name,
                                                lLearnerName = dTb.learner_last_name,
                                                mLearnerName = dTb.learner_middle_name,
                                                statDate = dTb.stat_date,
                                                dissId = dTb.dissertation_id,
                                                dissTitle = dTb.i899a_title_of_diss,
                                                DeptName = dTb.department_name,
                                                degProgCode = dTb.degree_program_code.ToUpper()

                                            }).ToList();


                            return BDisList;

                        }
                        catch (Exception exception)
                        {
                            ExceptionLogger.Log(ExceptionLogger.SeverityLevels.fatal, exception, "Next action is to re-throw this exception object");
                        }

                        break;

                    case Schools.Psy:


                        try
                        {
                            var degprogPid = new int[] { 22 };
                            var degProgPStat = new string[] { "Graduate", "Pending Grad" };

                            var PDisList = (from dTb in _ncuEntities.dissertation_checklist_report
                                            where dTb.dissertation_abstract_display == true
                                            && dTb.dissertation_abstract != ""
                                            && degprogPid.Contains((int)dTb.degree_program_id)
                                            && degProgPStat.Contains((string)dTb.degree_program_status)
                                            //orderby dTb.stat_date descending
                                            select new diss
                                            {
                                                fLearnerName = dTb.learner_first_name,
                                                lLearnerName = dTb.learner_last_name,
                                                mLearnerName = dTb.learner_middle_name,
                                                statDate = dTb.stat_date,
                                                dissId = dTb.dissertation_id,
                                                dissTitle = dTb.i899a_title_of_diss,
                                                DeptName = dTb.department_name,
                                                degProgCode = dTb.degree_program_code.ToUpper()

                                            }).ToList();
                            return PDisList;
                        }
                        catch (Exception exception)
                        {
                            ExceptionLogger.Log(ExceptionLogger.SeverityLevels.fatal, exception, "Next action is to re-throw this exception object");
                        }

                        break;

                    case Schools.Edu:

                        try
                        {
                            var degprogEid = new int[] { 31, 32 };
                            var degProgEStat = new string[] { "Graduate", "Pending Grad" };

                            var DisList = (from dTb in _ncuEntities.dissertation_checklist_report
                                           where dTb.dissertation_abstract_display == true
                                           && dTb.dissertation_abstract != ""
                                           && degprogEid.Contains((int)dTb.degree_program_id)
                                           && degProgEStat.Contains((string)dTb.degree_program_status)
                                           //orderby dTb.stat_date descending
                                           select new diss
                                           {
                                               fLearnerName = dTb.learner_first_name,
                                               lLearnerName = dTb.learner_last_name,
                                               mLearnerName = dTb.learner_middle_name,
                                               statDate = dTb.stat_date,
                                               dissId = dTb.dissertation_id,
                                               dissTitle = dTb.i899a_title_of_diss,
                                               DeptName = dTb.department_name,
                                               degProgCode = dTb.degree_program_code.ToUpper()

                                           }).ToList();


                            return DisList;
                        }
                        catch (Exception exception)
                        {
                            ExceptionLogger.Log(ExceptionLogger.SeverityLevels.fatal, exception, "Next action is to re-throw this exception object");
                        }
                        break;

                    case Schools.Mfs:
                        try
                        {
                            var degprogMid = new int[] { 34 };
                            var degProgMStat = new string[] { "Graduate", "Pending Grad" };

                            var DisList = (from dTb in _ncuEntities.dissertation_checklist_report
                                           where dTb.dissertation_abstract_display == true
                                           && dTb.dissertation_abstract != ""
                                           && degprogMid.Contains((int)dTb.degree_program_id)
                                           && degProgMStat.Contains((string)dTb.degree_program_status)
                                           //orderby dTb.stat_date descending
                                           select new diss
                                           {
                                               fLearnerName = dTb.learner_first_name,
                                               lLearnerName = dTb.learner_last_name,
                                               mLearnerName = dTb.learner_middle_name,
                                               statDate = dTb.stat_date,
                                               dissId = dTb.dissertation_id,
                                               dissTitle = dTb.i899a_title_of_diss,
                                               DeptName = dTb.department_name,
                                               degProgCode = dTb.degree_program_code.ToUpper()

                                           }).ToList();
                            return DisList;
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
        public diss GetAbstract(int id)
        {
            using (var _ncuEntities = new ncuEntities())
            {

                var degprogid = new string[] { "phd-ba", "edd", "phd-psy", "phd-mft", "phd-ed", "dba" };
                var degProgStat = new string[] { "Graduate", "Pending Grad" };

                var dissAbstract = (from data in _ncuEntities.dissertation_checklist_report
                                    where (data.dissertation_id == id)
                                    && degprogid.Contains((string)data.degree_program_code)
                                    && data.stat_date != null
                                    && degProgStat.Contains((string)data.degree_program_status)
                                    orderby data.stat_date descending
                                    select new diss
                                    {

                                        fLearnerName = data.learner_first_name,
                                        lLearnerName = data.learner_last_name,
                                        mLearnerName = data.learner_middle_name,
                                        dissTitle = data.i899a_title_of_diss,
                                        degProgCode = data.degree_program_code.ToUpper(),
                                        cFirstName = data.chair_mentor_first_name,
                                        cMidName = data.chair_mentor_middle_name,
                                        cLastName = data.chair_mentor_last_name,
                                        dissAbstract = data.dissertation_abstract,
                                        dissId = data.dissertation_id,
                                        degProgId = data.degree_program_id,
                                        chairId = data.chair_mentor_id,
                                        DeptId = data.department_id,
                                        DeptName = data.department_name

                                    }).FirstOrDefault();

                return dissAbstract;
            }
        }

        public IEnumerable<diss> GetChairName(string id)
        {

            using (var _ncuEntities = new ncuEntities())
            {
                var degprogid = new string[] { "phd-ba", "edd", "phd-psy", "phd-mft", "phd-ed", "dba" };
                var chairList = (from c in _ncuEntities.dissertation_checklist_report
                                 where c.chair_mentor_id == id
                                 && c.stat_date != null
                                 && degprogid.Contains((string)c.degree_program_code)
                                 && c.i899a_title_of_diss != ""
                                 && c.degree_program_status == "Graduate"
                                 orderby c.stat_date descending
                                 select new diss
                                 {
                                     cFirstName = c.chair_mentor_first_name,
                                     cMidName = c.chair_mentor_middle_name,
                                     cLastName = c.chair_mentor_last_name,
                                     Name = c.chair_mentor_first_name + " " + c.chair_mentor_middle_name + " " + c.chair_mentor_last_name,
                                     dissTitle = c.i899a_title_of_diss,
                                     degProgCode = c.degree_program_code.ToUpper(),
                                     dissId = c.dissertation_id,
                                     statDate = c.stat_date

                                 }).ToList();

                return chairList;
            }
        }

        public IEnumerable<diss> GetDissSearch(string a, string b)
        {
            //int dissDrop = Convert.ToInt32(a);
            DissDropDown dissDrop;
            Enum.TryParse(a, out dissDrop);

            String searchVar = b;
            var degprogid = new int[] { 8, 17, 20, 22, 23, 31, 34 };
            var degProgStat = new string[] { "Graduate", "Pending Grad" };

            //convert this to a switch rather than using the if/else statement. Also I am going to  
            using (var _ncuEntities = new ncuEntities())
            {
                switch (dissDrop)
                {
                    case DissDropDown.Title:

                        try
                        {
                            var getSearch1 = (from searchDb in _ncuEntities.dissertation_checklist_report
                                              where searchDb.i899a_title_of_diss.Contains(searchVar)
                                              && searchDb.dissertation_abstract_display == true
                                              && searchDb.dissertation_abstract != ""
                                              && degprogid.Contains((int)searchDb.degree_program_id)
                                              && degProgStat.Contains((string)searchDb.degree_program_status)
                                              orderby searchDb.learner_last_name
                                              select new diss
                                              {
                                                  LearnerName = searchDb.learner_first_name + " " + searchDb.learner_last_name,
                                                  fLearnerName = searchDb.learner_first_name,
                                                  lLearnerName = searchDb.learner_last_name,
                                                  mLearnerName = searchDb.learner_middle_name,
                                                  statDate = searchDb.stat_date,
                                                  dissId = searchDb.dissertation_id,
                                                  dissTitle = searchDb.i899a_title_of_diss,
                                                  DeptName = searchDb.department_name,

                                              }).ToList();
                            return getSearch1;

                        }
                        catch (Exception exception)
                        {
                            ExceptionLogger.Log(ExceptionLogger.SeverityLevels.fatal, exception, "Next action is to re-throw this exception object");
                        }                  

                        break;
                    case DissDropDown.Author:

                        try
                        {
                            String strSearchString = Regex.Replace(b, ",", "");

                            string[] sArray = strSearchString.Split();

                            foreach (string t in sArray)
                            {
                                //string the_name = null;
                                var getSearch2 = (from searchDb in _ncuEntities.dissertation_checklist_report
                                                  where (sArray.Any(sa => searchDb.learner_last_name.Contains(sa))
                                                  || (sArray.Any(sa => searchDb.learner_first_name.Contains(sa))))
                                                  && searchDb.dissertation_abstract_display == true
                                                  && searchDb.dissertation_abstract != ""
                                                  && searchDb.i899a_title_of_diss != ""
                                                  && degprogid.Contains((int)searchDb.degree_program_id)
                                                  && degProgStat.Contains((string)searchDb.degree_program_status)
                                                  && searchDb.stat_date != null
                                                  orderby searchDb.learner_last_name
                                                  select new diss
                                                  {
                                                      fLearnerName = searchDb.learner_first_name,
                                                      lLearnerName = searchDb.learner_last_name,
                                                      mLearnerName = searchDb.learner_middle_name,
                                                      dissId = searchDb.dissertation_id,
                                                      dissTitle = searchDb.i899a_title_of_diss,
                                                      DeptName = searchDb.department_name

                                                  }).ToList();

                                return getSearch2;
                            }

                        }

                        catch (Exception exception)
                        {
                            ExceptionLogger.Log(ExceptionLogger.SeverityLevels.fatal, exception, "Next action is to re-throw this exception object");
                        }                     

                        break;

                    case DissDropDown.Abstract:

                        try
                        {
                            var getSearch3 = (from searchDb in _ncuEntities.dissertation_checklist_report
                                              where searchDb.dissertation_abstract_display == true
                                              && searchDb.dissertation_abstract.Contains(searchVar)
                                              && degprogid.Contains((int)searchDb.degree_program_id)
                                              && degProgStat.Contains((string)searchDb.degree_program_status)
                                              orderby searchDb.learner_last_name
                                              select new diss
                                              {
                                                  fLearnerName = searchDb.learner_first_name,
                                                  lLearnerName = searchDb.learner_last_name,
                                                  mLearnerName = searchDb.learner_middle_name,
                                                  statDate = searchDb.stat_date,
                                                  dissId = searchDb.dissertation_id,
                                                  dissTitle = searchDb.i899a_title_of_diss,
                                                  DeptName = searchDb.department_name,

                                              }).ToList();

                            return getSearch3;
                            
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

    }
}