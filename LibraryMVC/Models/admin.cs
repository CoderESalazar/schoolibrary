using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LibraryMVC4.Models
{

    //this classs will hold all properties related to activities that Users perform. So it will inherit all properties from Users. 
    //Activites that users perform can be broken into three categories: asking/viewing questions, posting comments, scheduling workshops and research consults, 
    //even attaching files that users can view. 
    //more importantly librarians can use this area to manage their day-to-day tasks and this will house methods that allow this type of activity
    //other activies like asking/viewing questions can be managed in different controllers. 

    public class admin : user
    {
        //Questions
        public int? QuestId { get; set; }
        public string QuestStatus { get; set; }
        public string QuestType { get; set; }

        [Required(ErrorMessage = "*Response Required")]
        public string QuestDetail { get; set; }

        [Required(ErrorMessage = "*Response Required")]
        public string Comments { get; set; }

        public DateTime? DateTime { get; set; }
        public DateTime? LibDateTime { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string Category { get; set; }//this set to new_cat in the table. Different from cat_id
        public int? CatDesc { get; set; }//this is set to cat_des in the qt table, but also lib_cat in the ql_table. Different from cat_name or cat_id        
        public DateTime? EmailSent { get; set; }

        //Still related to question but are TinyMCE properties too. 
        //need to add this back in. 
        [Required(ErrorMessage = "*Response Required")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string UserQuestion { get; set; }

        //Getting a librarian response
        [Required(ErrorMessage = "*Response Required")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string LibrarianResponse { get; set; }

        //Getting back edited librarian response
        [Required(ErrorMessage = "*Response Required")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string LibResponseEdit { get; set; }
        
        //Items related to User files
        [StringLength(50, MinimumLength = 3, ErrorMessage="Please be sure that File Name is below 50 characters.")]
        public string FileUpload { get; set; }
        public string FileName { get; set; }

        //Drop down menu for reassigning of librarian to assigned question
        public IEnumerable<SelectListItem> GetLibrarian { get; set; }
        [Required(ErrorMessage = "*Please select")]
        public string LibStringId { get; set; }
                        
        //librarians can use this dropdown for inputting phone/email/chat questions
        [Required(ErrorMessage = "*Please select")]        
        public string GetQTypeId { get; set; }
        public SelectList QType { get; set; }
        
        //Librarian can use drop down to assign proper category
        public IEnumerable<SelectListItem> GetCatList { get; set; }
        [Required(ErrorMessage = "*Please select")]
        public int CatId { get; set; } //set to cat_id in the quest_lib table. 
        public string CatName { get; set; }

        public bool CheckBox { get; set; }
             
        [Required(ErrorMessage = "*Please select")]
        public string CatQId { get; set; } //not the same as CatId and only contains reference to "Submitted to KB"
        public SelectList GetCatQs { get; set; }

        public string CourseNum { get; set; } //qt table
        public string AssignNum { get; set; } //qt table   

        public string UserQNoValidation { get; set; }

        public bool Display { get; set; }


    } 

}