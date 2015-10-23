using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LibraryMVC4.Models
{
    public class diss
    {
        //clean up properties so they are similar to other model properties. 
        public string DeptId { get; set; }
        public string DeptName { get; set; }
        public string fLearnerName { get; set; }
        public string lLearnerName { get; set; }
        public string mLearnerName { get; set; }
        public DateTime? statDate { get; set; }
        public int dissId { get; set; }
        public string degProgCode { get; set; }
        public string dissTitle { get; set; }
        public int? degProgId { get; set; }
        public string cFirstName { get; set; }
        public string cMidName { get; set; }
        public string cLastName { get; set; }
        public string dissAbstract { get; set; }
        public string LearnerName { get; set; }
        public string chairId { get; set; }
        public string DegProgStatus { get; set; }
        public string Name { get; set; }                  

        //FileDownlad Diss Checklist

        public int DissCheckId { get; set; }
        public string dissFileName { get; set; }
        public Byte[] dissFile { get; set; }

        //Dissertation Search 
        public IEnumerable<SelectListItem> DissList { get; set; }
        
        [Required]
        public String DropDrownMenuVar { get; set; }

        
        //[Required]
        [Required(ErrorMessage = "*Please type into the search box!")]
        public String SearchVariables { get; set; }
        
    }
}