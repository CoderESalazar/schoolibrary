using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMVC4.Models
{
    public class sitemap
    {
  
        public int? HighId { get; set; }
        public string PageTitle { get; set; }
        public int? ParentId { get; set; }

        public string PageType { get; set; }
        //public string Url { get; set; }
        public string LinkData { get; set; }
        //public string DescText { get; set; }
        public int? DisplayOrder { get; set; }
     
        
         
    }
}