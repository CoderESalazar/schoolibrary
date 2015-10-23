using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LibraryMVC4.Models
{
    public class user
    {
        //we will have three different types of users using the system: students, librarians, and faculty
        //all info relating users will be presented below. that students, staff, faculty have been merged into a single user. 
       
        //the following properties belong to patrons
        public string PatronFirstName { get; set; }
        public string PatronLastName { get; set; }
        public string PatronName { get; set; }
        public string PatronPhysicalAddress { get; set; }
        public string PostalCode { get; set; }
        public string PatronId { get; set; }
        public string PatronEmail { get; set; }
        public string PatronPhone { get; set; }
        public string DegProg { get; set; }

        //the following properties belong to the librarian
        public string LibLastName { get; set; }
        public string LibName { get; set; }
        public int LibId { get; set; } 
        public string LibAdminGroup { get; set; }
      

    }
}