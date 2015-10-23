using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMVC4.Models
{
    public class mm
    {
        public string titleName { get; set; }
        public int highId { get; set; }
        public int? parentId { get; set; }
        public string tName { get; set; }
        public string pageType { get; set; }
        //public string MyProperty { get; set; }

        //properties for breadcrumb
        public int HighId { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public string PageType { get; set; }
        public string LinkData { get; set; }
        public int? DisplayOrder { get; set; }
    }
}