using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PagedList;


namespace LibraryMVC4.Models
{
    public class guides : dbindex
    {
        //library guide        
        public string TitleHeader { get; set; }
        public int? HeaderId { get; set; }
        public int? GuideId { get; set; }
        public int? DisplayOrder { get; set; }

        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string GuideBody { get; set; }

        public string CGuideTitle { get; set; }

        [UIHint("tinymce_jquery_full"), AllowHtml]
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

        //[Display(Name="CourseGuide")]
        public string CourseCode { get; set; }
        public IEnumerable<SelectListItem> GuideList { get; set; }
        public string CourseName { get; set; }
        public int? Enrollees { get; set; }
        public bool? Display { get; set; }
        public string LastName { get; set; }
        public DateTime? CourseEndDate { get; set; }

        //spec guide admin
        public string DeptSpecId { get; set; }
        public string School { get; set; }
        public int DeptGuideMainId { get; set; }
        public int? DeptDiscpId { get; set; }

        [Required(ErrorMessage = "*Title Required")]
        public string ResourceTitle { get; set; }
        [Required(ErrorMessage = "*Url Required")]
        public string ResourceUrl { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string ResourceDesc { get; set; }
        
        public string SectionName { get; set; }
        public string HeaderName { get; set; }

        public IEnumerable<SelectListItem> HeaderList { get; set; }

        public int GuideResourceId { get; set; }

        //course guide tabs
        public int TabId { get; set; }
        public string TabName { get; set; }
        public IEnumerable<SelectListItem> TabList { get; set; }

        //webgrid Search example
        public int? Page { get; set; }
        public IPagedList<guides> SearchResults { get; set; }
        public string SearchButton { get; set; }
    }
}