using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMVC4.Models
{
    public class SiteMapRecursion
    {
        public int HighId { get; set; }
        public int? ParentId { get; set; }

        public string PageTitle { get; set; }
        public string PageType { get; set; }
        public int? iParentId { get; set; } 
        public string LinkData { get; set; }

        public List<SiteMapRecursion> Children { get; set; }

    }
}