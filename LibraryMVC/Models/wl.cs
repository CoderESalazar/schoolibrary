using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LibraryMVC4.Models
{
    public class wl : structure
    {
        public string Links { get; set; }
        public string LinkDesc { get; set; }        
        public int GetCount { get; set; }

        [Required(ErrorMessage = "*A URL is required")]
        public string GetUrl { get; set; }
        public int? Order { get; set; }
        public int LinkId { get; set; }
        public int DbKeyId { get; set; }
        public int StructId { get; set; }

        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string ResourceText { get; set; }
    }
}