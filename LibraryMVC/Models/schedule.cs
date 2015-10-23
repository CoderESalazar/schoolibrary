using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMVC4.Models
{
    public class schedule : admin
    {    
        public int lcEventId { get; set; } //libcalendar table
        public int? lrEventId { get; set; } //libregisterees
        public DateTime? eventDate { get; set; }
        public string eventDetails { get; set; }
        public string attendDetails { get; set; }
        public string workShopTitle { get; set; }

        public int? TotalAttendees { get; set; }
        public string Registerees { get; set; }
        
    }
}