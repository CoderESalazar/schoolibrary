using LibraryMVC4.Entity;
using LibraryMVC4.Models;
using LibraryMVC4.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using Ncu.Logging.Logger;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

namespace LibraryMVC4.Repository
{
    public class AdminRepository : IAdmin<admin>
    {        
       
        public IEnumerable<admin> GetAll()
        {
            using (var _ncuElrc = new LibEntities())
            {
                var getAskLibQs = (from qt in _ncuElrc.quest_tb
                                   where qt.q_status == null && qt.q_type == null
                                   orderby qt.date_time descending
                                   select new admin
                                   {
                                       QuestId = qt.q_id,
                                       DateTime = qt.date_time,
                                       PatronFirstName = qt.u_first_name,
                                       PatronLastName = qt.u_last_name,
                                       QuestStatus = qt.q_status,
                                       CatDesc = qt.cat_desc,
                                       QuestType = qt.q_type,
                                       PatronName = qt.u_first_name + " " + qt.u_last_name
                                   }).ToList();

                return getAskLibQs;
            }

        }

        public IEnumerable<admin> GetList()
        {

            //Need to update the stored procedures so that I join with file_uploads. 
            using (var _ncuElrc = new LibEntities())
            {
                var getKbQuests = (from gq in _ncuElrc.GetKbQuestions()
                                   select new admin
                                   {
                                       QuestId = gq.q_id,
                                       DateTime = gq.date_time,
                                       LibDateTime = gq.lib_date_time,
                                       Category = gq.new_cat,
                                       LibLastName = gq.last_name,
                                       PatronLastName = gq.u_last_name,
                                       DegProg = gq.deg_prog,
                                       QuestType = gq.q_type,
                                       EmailSent = gq.email_sent,
                                       CourseNum = gq.course_num,
                                       FileUpload = gq.file_upload
                                   }).ToList();

                return getKbQuests;
            }
        }

        public IEnumerable<admin> List()
        {

            using (var _ncuElrc = new LibEntities())
            {
                var getThisList = (from qc in _ncuElrc.quest_cat
                                   orderby qc.cat_name
                                   select new admin
                                   {
                                       CatName = qc.cat_name,
                                       CatId = qc.cat_id,
                                       CheckBox = qc.display,
                                       DateTime = qc.date_time
                                   }).ToList();

                return getThisList;
            }

        }

        public admin GetById(int id)
        {
            //so far this datacollection is only for the library questions that appear from queque NOT submitted library questions.
            //what I need to know is can this be used to pull info for queque for submitted library questions. Yes, for both queues. 
            //need to add q_status to the stored procedure so that we can finish out the page. 

            using (var _ncuElrc = new LibEntities())
            { 

                var getPatronInfo = (from gp in _ncuElrc.GetPatronInfo(id)
                                     select new admin
                                     {
                                         QuestId = gp.q_id,
                                         PatronName = gp.u_first_name + " " + gp.u_last_name,
                                         PatronPhysicalAddress = gp.address_street + " " + gp.address_city + " " + gp.address_state + " " + gp.address_postal_code + " " + gp.country,
                                         PatronPhone = gp.phone_1,
                                         DateTime = gp.date_time,
                                         PatronEmail = gp.email_address,
                                         CourseNum = gp.course_num,
                                         AssignNum = gp.assign_num,
                                         PatronId = gp.user_id,
                                         Category = gp.new_cat,
                                         UserQuestion = gp.q_detail,
                                         QuestStatus = gp.q_status,
                                         LibrarianResponse = gp.lib_response,
                                         LibResponseEdit = gp.lib_q_edit

                                     }).FirstOrDefault();

                return getPatronInfo;

            }

        }

        public admin GetByKeyId(int id)
        {

            //definitely ned this for the category we also have the userquestion from the qt table. 
            //Going to handle Librarian Assigned Qs. 
            //I believe we need to add some type of response which might eliminate the firing off of the validation that happening twice. Give it a tyr. 

            using (var _ncuElrc = new LibEntities())
            {
                var getAssignInfo = (from gp in _ncuElrc.GetAssignInfo(id)
                                     select new admin
                                     {
                                         QuestId = gp.q_id,
                                         PatronName = gp.u_first_name + " " + gp.u_last_name,
                                         PatronPhysicalAddress = gp.address_street + " " + gp.address_city + " " + gp.address_state + " " + gp.address_postal_code + " " + gp.country,
                                         //PostalCode = gp.address_postal_code,
                                         PatronPhone = gp.phone_1,
                                         DateTime = gp.date_time,
                                         PatronEmail = gp.email_address,
                                         CourseNum = gp.course_num,
                                         AssignNum = gp.assign_num,
                                         PatronId = gp.user_id,
                                         Category = gp.cat_name,
                                         UserQuestion = gp.q_detail                                         

                                     }).FirstOrDefault();

                return getAssignInfo;

            }

        }

        public object Edit(admin entity)
        {
            LibEntities _ncuElrc = new LibEntities();
            bool result = false;
            int? qId = entity.QuestId;
         
            quest_lib ql = _ncuElrc.quest_lib.FirstOrDefault(m => m.q_id == qId);
                       
            try
            {
                if (ql.q_id != null && ql.q_status.Contains("Partial"))
                {
                    ql.lib_cat = entity.CatId;
                    ql.q_status = entity.CatQId;
                    ql.lib_q_edit = entity.UserQuestion;
                    ql.lib_response = entity.LibrarianResponse;
                   
                    _ncuElrc.SaveChanges();

                    result = true;
                    //we need to see if file is being added to the question. wonder if it will work with a partial. Need find record in database and display it.  
                    if (entity.FileUpload != null)
                    {
                        SaveFile(entity.QuestId);
                    }
                    //we only send and email if question is tagged with "submitted to KB"
                    if (entity.CatQId.Contains("Submitted to KB"))
                    {
                        SendEmail(qId);
                    }
                    
                }
                else
                {
                    ql.lib_cat = entity.CatId;
                    ql.lib_q_edit = entity.LibResponseEdit;
                    ql.lib_response = entity.LibrarianResponse;
                    ql.cat_id = entity.CheckBox;

                    _ncuElrc.SaveChanges();

                    result = true;
                }

            }
            catch (Exception exception)
            {

                ExceptionLogger.Log(ExceptionLogger.SeverityLevels.fatal, exception, "Next action is to re-throw this exception object");
                result = false;
                //transaction.Dispose();
            }
            finally
            {
                _ncuElrc.Connection.Close();
            }

            return result;

        }
        public object Add(admin entity)
        {
            LibEntities _ncuElrc = new LibEntities();
            bool result = false;
            try
            {
                var questCat = new quest_cat
                {
                    cat_name = entity.CatName,
                    date_time = DateTime.Now,
                    display = true
                };

                _ncuElrc.quest_cat.AddObject(questCat);
                _ncuElrc.SaveChanges();
            }
            catch (Exception exception)
            {
                ExceptionLogger.Log(ExceptionLogger.SeverityLevels.fatal, exception, "Next action is to re-throw this exception object");
                result = false;
            }
            finally
            {
                _ncuElrc.Connection.Close();
            }
            return result;

        }

        public object Delete(int id)
        {
            //we'll try to pass lib_id to this so we can delete the dupe.

            using (var _ncuElrc = new LibEntities())
            {
                var deleteQ = _ncuElrc.quest_lib.FirstOrDefault(t => t.q_id == id);

                if (deleteQ == null)
                {
                    return false;
                }
                else
                {
                    _ncuElrc.DeleteObject(deleteQ);
                    _ncuElrc.SaveChanges();
                    return true;
                }
            }
        }
        private static void SendEmail(int? id)
        {
           using (var _ncuElrc = new LibEntities())
           { 
                quest_tb qt = _ncuElrc.quest_tb.FirstOrDefault(x => x.q_id == id);

                if (qt != null)
                {
                    MailMessage mail = new MailMessage();

                    SmtpClient smtpServer = new SmtpClient("smtp.ncu.edu");

                    mail.From = new MailAddress("library@ncu.edu");
                    //this is a test to see if email is sent.  
                    mail.To.Add(qt.email_address);
                    //mail.To.Add(qt.email_address);
                    mail.Subject = "Ask a Librarian Response";
                    mail.Body = "Hello " + qt.u_first_name + ", there is now a response to your question submitted " + qt.date_time +
                    ". Please click the following link to view the Librarian's response http://library.ncu.edu/asklib in the My e-Reference Area.";

                    smtpServer.Send(mail);

                    EmailUpdate(id);
                }
           }

        }
        private static void EmailUpdate(int? id)
        {
            using (var _ncuElrc = new LibEntities()) 
            { 
                quest_lib ql = _ncuElrc.quest_lib.FirstOrDefault(x => x.q_id == id);

                ql.email_sent = DateTime.Now;

                _ncuElrc.SaveChanges();
            }

        }
        public IEnumerable<admin> GetSubmittedQs()
        {
            using (var _ncuElrc = new LibEntities())
            {

                var getSubmittedQs = (from qt in _ncuElrc.quest_tb
                                      where qt.q_status == null
                                      select new admin
                                      {
                                          QuestId = qt.q_id,
                                          DateTime = qt.date_time,
                                          PatronFirstName = qt.u_first_name,
                                          PatronLastName = qt.u_last_name,
                                          QuestStatus = qt.q_status,
                                          QuestType = qt.q_type

                                      }).ToList();

                return getSubmittedQs;
            }
        }

        public IEnumerable<admin> GetAssignQs()
        {
            using (var _ncuElrc = new LibEntities())
            {
                var getAssignQs = (from ga in _ncuElrc.GetAssignedQs()
                                   select new admin
                                   {
                                       QuestId = ga.q_id,
                                       DateTime = ga.lib_date_time,
                                       Category = ga.new_cat,
                                       LibLastName = ga.last_name,
                                       PatronLastName = ga.u_last_name,

                                   }).ToList();

                return getAssignQs;
            }

        }
        public IEnumerable<admin> GetSubmittedQsNo()
        {
            using (var _ncuElrc = new LibEntities())
            { 
                var getSubmittedQsNo = (from gs in _ncuElrc.GetKbQsNo()
                                        select new admin
                                        {
                                            QuestId = gs.q_id,
                                            DateTime = gs.date_time,
                                            LibDateTime = gs.lib_date_time,
                                            Category = gs.new_cat,
                                            LibLastName = gs.last_name,
                                            PatronLastName = gs.u_last_name,
                                            DegProg = gs.deg_prog,
                                            QuestType = gs.q_type,
                                            EmailSent = gs.email_sent,
                                            CourseNum = gs.course_num,
                                            FileName = gs.attachment_file_name
                                        }).ToList();
                return getSubmittedQsNo;
            }

        }
        public IEnumerable<admin> GetLibAdminPeople()
        {

            using (var _ncuElrc = new LibEntities())
            {

                var getLibAdminPeople = (from lp in _ncuElrc.lib_admin_people
                                         orderby lp.lib_name
                                         select new admin
                                         {

                                             LibName = lp.lib_name,
                                             LibStringId = lp.lib_string_id

                                         }).ToList();

                return getLibAdminPeople;
            }
        }
        public object EditLibPerson(admin entity, int id)
        {
            LibEntities _ncuElrc = new LibEntities();
            bool result = false;
            quest_lib ql = _ncuElrc.quest_lib.FirstOrDefault(m => m.q_id == id);

            try
            {
                if (ql != null)
                {
                    ql.lib_userid = entity.LibStringId;

                    _ncuElrc.SaveChanges();
                    result = true;
                }
            }
            catch (Exception exception)
            {
                ExceptionLogger.Log(ExceptionLogger.SeverityLevels.fatal, exception, "Next action is to re-throw this exception object");
                result = false;
            }
            finally
            {
                _ncuElrc.Connection.Close();
            }

            return result;

        }
        public object EditCategory(admin entity)
        {
            bool result = false;
            LibEntities _ncuElrc = new LibEntities();
            quest_cat qc = _ncuElrc.quest_cat.FirstOrDefault(m => m.cat_id == entity.CatId);

            try
            {
                if (qc != null)
                {
                    //qc.cat_id = entity.CatId;
                    qc.cat_name = entity.CatName;
                    qc.display = entity.CheckBox;
                    qc.date_time = DateTime.Now;

                    _ncuElrc.SaveChanges();
                    result = true;
                }
            }
            catch (Exception exception)
            {
                ExceptionLogger.Log(ExceptionLogger.SeverityLevels.fatal, exception, "Next action is to re-throw this exception object");
                result = false;
            }
            finally
            {
                _ncuElrc.Connection.Close();
            }
            return result;
        }
        public IEnumerable<admin> GetCatList()
        {

            using (var _ncuElrc = new LibEntities())
            {
                var getMyList = (from cat in _ncuElrc.quest_cat
                                 where cat.display == true
                                 orderby cat.cat_name
                                 select new admin
                                 {
                                     CatId = cat.cat_id,
                                     CatName = cat.cat_name

                                 }).ToList();

                return getMyList;
            }
        }

        public admin PatronInfo(string id)
        {

            using (var ncuConn = new ncuEntities())
            {

                var getUserName = (from LiTb in ncuConn.learner_info
                                   //join LP in ncuConn.learner_programs on LiTb.learner_id equals LP.learner_id
                                   where LiTb.learner_id == id
                                   select new admin
                                   {
                                       PatronId = LiTb.learner_id,
                                       PatronFirstName = LiTb.first_name,
                                       PatronLastName = LiTb.last_name,
                                       //degProg = LP.degree_program_code,
                                       PatronEmail = LiTb.email_address_1

                                   }).FirstOrDefault();


                if (getUserName == null)
                {
                    var getMentorName = (from MnTb in ncuConn.mentor_info
                                         where MnTb.mentor_id == id
                                         select new admin
                                         {
                                             PatronId = MnTb.mentor_id,
                                             PatronFirstName = MnTb.first_name,
                                             PatronLastName = MnTb.last_name,
                                             PatronEmail = MnTb.email_address_public

                                         }).FirstOrDefault();

                    if (getMentorName == null)
                    {

                        var getStaffName = (from SfTb in ncuConn.staff_info
                                            where SfTb.staff_id == id
                                            select new admin
                                            {
                                                PatronId = SfTb.staff_id,
                                                PatronFirstName = SfTb.first_name,
                                                PatronLastName = SfTb.last_name,
                                                PatronEmail = SfTb.email_address

                                            }).FirstOrDefault();

                        if (getStaffName == null)
                        {

                            return null;

                        }

                        return getStaffName;

                    }

                    return getMentorName;

                }

                return getUserName;
            }
        }

        public object AddPhoneQt(admin entity)
        {
            LibEntities _ncuElrc = new LibEntities();
            bool result = false;
            try
            {
                var quest_tb = new quest_tb
                {
                    user_id = entity.PatronId,
                    u_first_name = entity.PatronFirstName,
                    u_last_name = entity.PatronLastName,
                    email_address = entity.PatronEmail,
                    date_time = DateTime.Now,
                    q_type = entity.GetQTypeId,
                    cat_desc = entity.CatId,
                    course_num = entity.CourseNum,
                    assign_num = entity.AssignNum,
                    q_detail = entity.UserQuestion,
                    lib_response = entity.LibrarianResponse
                    //may need to add librarian last name here? Can't see why if we are going to capture that info in the QL table. Might be overkill. 

                };

                _ncuElrc.quest_tb.AddObject(quest_tb);
                _ncuElrc.SaveChanges();

                AddPhoneMethod(entity);
                result = true;            
            }
            catch (Exception exception)
            {
                ExceptionLogger.Log(ExceptionLogger.SeverityLevels.fatal, exception, "Next action is to re-throw this exception object");
                //result = false;
            }
            finally
            {
                _ncuElrc.Connection.Close();
            }
            return result;
        }
        private object AddPhoneMethod(admin _objectList)
        {
            LibEntities _ncuElrc = new LibEntities();
            bool result = false;
            try
            {
                int getQId = GetQId();
                var quest_lib = new quest_lib
                {
                    lib_userid = LibSecurity.UserId,
                    //lib_userid = "7304205318",
                    lib_date_time = DateTime.Now,
                    q_id = getQId,
                    q_status = "Not Submitted to KB",
                    cat_id = false,
                    lib_cat = _objectList.CatId,
                    lib_q_edit = _objectList.UserQuestion,
                    lib_response = _objectList.LibrarianResponse,
                    u_last_name = _objectList.PatronLastName,
                    q_type = _objectList.GetQTypeId
                    
                };

                _ncuElrc.quest_lib.AddObject(quest_lib);
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
        private int GetQId()
        {
            using (var _ncuElrc = new LibEntities())
            {
                var getMyId = (from qt in _ncuElrc.quest_tb.Take(2)
                               where qt.q_type != null
                               orderby qt.q_id descending
                               select qt.q_id);

                foreach (var i in getMyId)
                {
                    int[] ids = { i };

                    return ids[0];
                }
                return 0;

            }
            //return result;
        }       
        public object AddQ(admin entity)
        {
            LibEntities _ncuElrc = new LibEntities(); 
            bool result = false;
            //going to check and see if the question has been already added to the database. 

            int? qId = entity.QuestId;

            var questCheck = _ncuElrc.quest_lib.FirstOrDefault(t => t.q_id == qId);

            //if questCheck is null then it's not in the database. so we need to add it. 
            if (questCheck == null)
            {
                int? questDesc1 = GetCatDesc(entity);

                UserRepository myPatronInfo = new UserRepository();
                var t = myPatronInfo.GetUserInfo();
                //user myUser = UserRepository.GetUserInfo();                
              
                try
                {
                    var quest_lib = new quest_lib
                    {
                        lib_userid = t.PatronId,
                        lib_date_time = DateTime.Now,
                        q_id = qId,
                        lib_q_edit = entity.UserQNoValidation,
                        lib_cat = (int)questDesc1,
                        q_status = "Partial",
                        cat_id = true,
                        u_last_name = entity.PatronLastName,
                    };

                    _ncuElrc.quest_lib.AddObject(quest_lib);
                    //_libEntity.Detach(entity.QuestId);
                    //_ncuElrc.DetectChanges();
                    _ncuElrc.SaveChanges();                                     

                    result = true;
                }
                catch (Exception exception)
                {
                    ExceptionLogger.Log(ExceptionLogger.SeverityLevels.fatal, exception, "Next action is to re-throw this exception object");
                    result = false;
                }
                finally
                {
                    _ncuElrc.Connection.Close();
                }
            }
            return result;


        }
        private int? GetCatDesc(admin entity)
        {
            using (var _ncuElrc = new LibEntities())
            {
                var questDesc = _ncuElrc.quest_tb.FirstOrDefault(c => c.q_id == (int)entity.QuestId);
                return questDesc.cat_desc;

            }
        }
        public admin GetAssignQ(int id)
        {
            using (var _ncuElrc = new LibEntities())
            { 
                var getAssignQ = (from gp in _ncuElrc.GetAssignInfo(id)
                                     select new admin
                                     {
                                         QuestId = gp.q_id,
                                         PatronName = gp.u_first_name + " " + gp.u_last_name,
                                         PatronLastName = gp.u_last_name,
                                         PatronPhysicalAddress = gp.address_street + " " + gp.address_city + " " + gp.address_state + " " + gp.address_postal_code + " " + gp.country,
                                         //PostalCode = gp.address_postal_code,
                                         PatronPhone = gp.phone_1,
                                         DateTime = gp.date_time,
                                         PatronEmail = gp.email_address,
                                         CourseNum = gp.course_num,
                                         AssignNum = gp.assign_num,
                                         PatronId = gp.user_id,
                                         Category = gp.cat_name,
                                         UserQNoValidation = gp.q_detail

                                     }).FirstOrDefault();

                return getAssignQ;
            }
        }


        public admin CategoryEdit(int id)
        {
            using (var _ncuElrc = new LibEntities())
            {
                var getCatInfo = (from q in _ncuElrc.quest_cat
                                  where q.cat_id == id
                                  select new admin
                                  {
                                      CatName = q.cat_name,
                                      CheckBox = q.display,
                                      CatId = q.cat_id
                                  }).FirstOrDefault();

                return getCatInfo;
            }

        }

         private static void SaveFile(int? myIntObject) {

            using (var _ncuElrc = new LibEntities())
            {
                var request = HttpContext.Current.Request;

                if (request.Files.Count > 0)
                {
                    int countFiles = 0;

                    var fileName = request.Files[countFiles];

                    //checking length of file to see if we can use otherwise length of file name can sink this operation. 
                    int length = fileName.FileName.Length;

                    String fileExtension = String.Empty;

                    //if file's content length is zero or no files submitted. 
                    //see if this code can be moved to repository...might be called and used elsewhere in the application
                    if (fileName.ContentLength > 0 && fileName.ContentLength < 4 * 1024 * 1024)
                    {
                        int fileLen = fileName.ContentLength;
                        var input = new byte[fileLen];

                        Stream myStream = fileName.InputStream;
                        myStream.Read(input, 0, fileLen);
                        if (fileName != null)
                        {

                            string[] fileNameArr = fileName.FileName.Split('.');
                            fileExtension = fileNameArr[fileNameArr.Length - 1];

                        }

                        var fileUpload = new file_uploads
                        {

                            attachment_file_name = fileName.FileName,
                            attachment_file_type = fileExtension,
                            q_id = myIntObject,
                            attachment_file = input

                        };

                        _ncuElrc.file_uploads.AddObject(fileUpload);
                        _ncuElrc.SaveChanges();
                    }

                }

            }

        }
        public admin GetCheckBox(int id)
        {
            using (var _ncuElrc = new LibEntities())
            {           
                var getCatId = (from ql in _ncuElrc.quest_lib
                                where ql.q_id == id
                                select new admin
                                {
                                    CheckBox = (bool)ql.cat_id 

                                }).FirstOrDefault();                               

                return getCatId;
            }
        }

        public IEnumerable<admin> GetFeedBack()
        {

            var _libConn = new LibEntities();
            var getFeedBack = (from gf in _libConn.feed_back
                               orderby gf.date_time descending
                               select new admin
                               {
                                   PatronName = gf.u_first_name + " " + gf.u_last_name,
                                   Comments = gf.notes_comments,
                                   PatronEmail = gf.email_address,
                                   DegProg = gf.deg_prog,
                                   DateTime = gf.date_time,
                                   PatronId = gf.user_id

                               }).Take(30);

            _libConn.Connection.Close();

            return getFeedBack;

        }

    }
}