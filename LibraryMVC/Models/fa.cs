using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMVC4.Models
{
    public class fa : dbindex
    {
        //public string dbTitle { get; set; }
        public string progTitle { get; set; }
        public string dbDescript { get; set; }
        //public string dbUrl { get; set; }
        public int dbProg { get; set; }
        public int dbNum { get; set; }

        public string school { get; set; }

        public string Title { get; set; }
        public int HighId { get; set; }

        public int? dbProgId { get; set; }

    }
}