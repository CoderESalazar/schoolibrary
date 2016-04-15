using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LibraryMVC4.Models
{
    public class blog
    {
        public int BlogId { get; set; }

        [Required(ErrorMessage = "*A post title is required")]
        public string BlogHeader { get; set; }

        [Required(ErrorMessage = "*Text Required")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string BlogText { get; set; }

        public DateTime? DateTime { get; set; }

    }
}