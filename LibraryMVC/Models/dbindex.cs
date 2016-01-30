using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LibraryMVC4.Models
{
    public class dbindex
    {
        [Required(ErrorMessage = "*Title Required")]
        public string dbTitle { get; set; }
        [Required(ErrorMessage = "*URL Required")]
        public string dbUrl { get; set; }
        public string dbCoverage { get; set; }
        public int dbKeyId { get; set; }
        public string dbType { get; set; } //subscription or freebie

        [Required(ErrorMessage = "*Description Required")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string dbDesc { get; set; }
        public bool dbDisplay { get; set; }
        public string dbScholarly { get; set; }
        public string dbFullText { get; set; }

        public IEnumerable<SelectListItem> GetDbDrop { get; set; }
    }
}