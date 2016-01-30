using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMVC4.Models
{
    public class schedule : admin
    {    
        public int lcEventId { get; set; } //libcalendar table
        public int? lrEventId { get; set; } //libregisterees
        
        [Required(ErrorMessage = "*Date and Time (include AM or PM) Required")]
        public DateTime eventDate { get; set; }

        [Required(ErrorMessage = "*Event Details Required")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string eventDetails { get; set; }
        
        public string attendDetails { get; set; }

        [Required(ErrorMessage = "*Workshop Title Required")]
        public string workShopTitle { get; set; }

        public int? TotalAttendees { get; set; }
        public string Registerees { get; set; }        
        
    }
}