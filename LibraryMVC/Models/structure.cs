using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LibraryMVC4.Models
{
    public class structure : admin
    {
        public int HighId { get; set; }
        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; }
        
        public int? ParentId { get; set; }
        [Required(ErrorMessage = "Please select a PageType.")]
        public string PageType { get; set; }
        public string LinkData { get; set; }
        public int? DisplayOrder { get; set; }
        public string PageTitle { get; set; }
        public string Text { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public bool ChatActive { get; set; }        
        public int? iParentId { get; set; }

        public List<structure> Children { get; set; }
                
        public IEnumerable<structure> GetPageTypeDd
        {
            get
            {
                return new List<structure>
                {
                    new structure { PageType = "dw", Text = "DW"},
                    new structure { PageType = "fa", Text = "FA"},
                    new structure { PageType = "mm", Text = "MM"},
                    new structure { PageType = "sw", Text = "SW"},
                    new structure { PageType = "wl", Text = "WL"},

                };

            }
        }
     }
}