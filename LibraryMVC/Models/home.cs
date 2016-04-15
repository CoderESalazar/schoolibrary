using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LibraryMVC4.Models
{
    public class home : admin
    {
        //Blog Header
        public string BlogHeader { get; set; }
        public int BlogHeaderId { get; set; }
        public string BlobBlob { get; set; }

        //Director's letter
        public int EntryId { get; set; }
        [Required(ErrorMessage = "*Title Required")]
        public string LetterTitle { get; set; }

        [Required(ErrorMessage = "*Text Required")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string LetterContent { get; set; }

        //Resource of the Month
        public int REntryId { get; set; }
        public string ResourceTitle { get; set; }
        public string ResourceContent { get; set; }
        public int? Ratings { get; set; }
        public string RateMyResource { get; set; }
        //public string comments_res { get; set; }

        public IEnumerable<SelectListItem> FaqList { get; set; }
        public string faqValue { get; set; }

        [UIHint("Integer")]
        public Int32 getMailCount { get; set; }

        //Alert Message
        public string AlertMess { get; set; }
        public string AlertTitle { get; set; }
        public bool AlertBit { get; set; }

        //Leave feedback properties
        [Required(ErrorMessage = "*Comment Required")]
        //public string comments { get; set; }

        //Library Chat
        public bool LibChat { get; set; }
        //public int LibId { get; set; }

        //radio button properties
        [Required(ErrorMessage = "Please select a rating.")]
        public string SelectRadioItem { get; set; }
        //public IList<RadioSelect> RadioItem { get; set; }

        public IEnumerable<RadioSelect> RadioItemR
        {
            get
            {
                return new[]
                {
                    new RadioSelect { Desc = "5" , Id = 5 }, 
                    new RadioSelect { Desc = "4", Id = 4 }, 
                    new RadioSelect { Desc = "3" , Id = 3 }, 
                    new RadioSelect { Desc = "2", Id = 2 }, 
                    new RadioSelect { Desc = "1", Id = 1 } 
                };
            }
        }
    }
    public class RadioSelect
    {
        public string Desc { get; set; }
        public int Id { get; set; }
             
    }
    //this will be a new radio button operation




}
