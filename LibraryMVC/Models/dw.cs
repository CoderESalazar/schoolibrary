﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMVC4.Models
{
    public class dw
    {
        public string TextDw { get; set; }
        public int HighId { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public string PageType { get; set; }
        public string LinkData { get; set; }
        public int? DisplayOrder { get; set; }
        
    }
}