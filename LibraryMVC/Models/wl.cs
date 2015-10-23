using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LibraryMVC4.Models
{
    public class wl : structure
    {
        public string Links { get; set; }
        public string LinkDesc { get; set; }        
        public int GetCount { get; set; }
        public string GetUrl { get; set; }
    }
}