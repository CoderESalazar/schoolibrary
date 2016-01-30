using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace LibraryMVC4.Models
{
    public class askalib
    {
        public int qId { get; set; } //qt table
        //public string userFName { get; set; } 
        //public string uLName { get; set; } 
        //public string userId { get; set; } 
        public DateTime? dateTime { get; set; } //qt table

        [Required(ErrorMessage = "*Question Required")]
        public string questDetail { get; set; } //qt table
        
        public string libResponse { get; set; } 
        public Boolean ViewedMess { get; set; } //ql table
        
        public int fId { get; set; } //file upload table
        public string fileName { get; set; } //file upload table

        //leave feedback properties for the ask a librarian. 
        [Required(ErrorMessage = "*Comment Required")]
        public string comments { get; set; }

        public IEnumerable<SelectListItem> CatList { get; set; }
        [Required(ErrorMessage = "*Please select")]
        public int CatId { get; set; }
        public string CatName { get; set; }

        
    }
}