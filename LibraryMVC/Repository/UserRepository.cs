using LibraryMVC4.Entity;
using LibraryMVC4.Models;
using LibraryMVC4.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Ncu.Logging.Logger;


namespace LibraryMVC4.Repository
{
    public class UserRepository : IUser<user>
    {

        public user GetUserInfo()
        {
            using (var ncuConn = new ncuEntities())
            {

                var getUserName = (from LiTb in ncuConn.learner_info
                                   join LP in ncuConn.learner_programs on LiTb.learner_id equals LP.learner_id
                                   where LiTb.learner_id == LibSecurity.UserId && LP.degree_program_code != "PROFDEV"
                                   select new user
                                   {
                                       PatronId = LiTb.learner_id,
                                       PatronFirstName = LiTb.first_name,
                                       PatronLastName = LiTb.last_name,
                                       DegProg = LP.degree_program_code,
                                       PatronEmail = LiTb.O365EmailAddress

                                   }).FirstOrDefault();

                if (getUserName == null)
                {
                    var getMentorName = (from MnTb in ncuConn.mentor_info
                                         //where MnTb.mentor_id == "7304205318"
                                         where MnTb.mentor_id == LibSecurity.UserId
                                         select new user
                                         {
                                             PatronId = MnTb.mentor_id,
                                             PatronFirstName = MnTb.first_name,
                                             PatronLastName = MnTb.last_name,
                                             PatronEmail = MnTb.email_address_public

                                         }).FirstOrDefault();

                    if (getMentorName == null)
                    {

                        var getStaffName = (from SfTb in ncuConn.staff_info
                                            //where SfTb.staff_id == "7304205318"
                                            where SfTb.staff_id == LibSecurity.UserId
                                            select new user
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

        public user LibAdminGroup()
        {
            using (var ncuConn = new ncuEntities())
            {
                var getLibraryAdmin = (from lg in ncuConn.letmein_groups
                                       from lu in lg.letmein_users
                                       //where lu.user_id == "7304205318" && lg.letmein_group_id == "LibraryAdmin"
                                       where lu.user_id == LibSecurity.UserId && lg.letmein_group_id == "LibraryAdmin"
                                       select new user
                                       {
                                           LibAdminGroup = lg.letmein_group_id

                                       }).FirstOrDefault();

                return getLibraryAdmin;
            }

        }
        public user GetFileName(int id)
        {
            throw new NotImplementedException();
        }

        public object AddUserPost(user entity)
        {
            throw new NotImplementedException();
        }   
    }
}