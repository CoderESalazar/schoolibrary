using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMVC4.Models
{
    public class res
    {
        [Required(ErrorMessage = "*Title Required")]
        public string ResourceTitle { get; set; }
        public DateTime? Date { get; set; }
        public bool Display { get; set; }
        public int EntryId { get; set; }

        [Required(ErrorMessage = "*Text Required")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string ResourceText { get; set; }

    }
}