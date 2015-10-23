using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMVC4.Models
{
    public class guides
    {
        //library guide
        
        public string TitleHeader { get; set; }
        public int? HeaderId { get; set; }
        public int? GuideId { get; set; }
        public int? DisplayOrder { get; set; }
        public string GuideBody { get; set; }
        public string CGuideTitle { get; set; }
        public string HeaderBody { get; set; }
        public IEnumerable<guides> GuideTabList { get; set; }
        public IEnumerable<guides> GuidBody { get; set; }

        //spec guide index
        public string GuideTitle { get; set; }
        public int? DeptId { get; set; }
        public int DeptGuideId { get; set; }
        public Boolean DisplayId { get; set; }
        public IEnumerable<SelectListItem> SpecList { get; set; }
        public string SpecBody { get; set; }
        public string SpecHeaders { get; set; }
        public string SpecResourceTitle { get; set; }
        public string urlSpecResource { get; set; }
        public string descSpecResource { get; set; }


        //course guide index

        public int GuidesId { get; set; }
        public string CourseCode { get; set; }
        public IEnumerable<SelectListItem> GuideList { get; set; }



    }
}