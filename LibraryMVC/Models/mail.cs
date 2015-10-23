using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LibraryMVC4.Models
{
    public class mail : admin
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Course { get; set; }
        public string Activity { get; set; }              
        
        [Required(ErrorMessage="*Question Required")]
        public string Question { get; set; }

        [Required(ErrorMessage="*Description of terms used")]
        public string StepsTaken { get; set; }
        
        [Required(ErrorMessage="Description of difficulties required")]
        public string Difficulties { get; set; }

        [Required(ErrorMessage = "Required assistance required")]
        public string RequestedAssistance { get; set; }

        [Required(ErrorMessage = "Time of day required")]
        public string timeOfDay { get; set; }

        [Required(ErrorMessage = "Referral source required")]
        public string referral { get; set; }

        [Required(ErrorMessage = "Research project status required")]
        public string projectStatus { get; set; }

        public IEnumerable<SelectListItem> projectDesc
        {

            get
            {
                return new[]
                {
                    new SelectListItem { Value = "I am still formulating my topic", Text = "I am still formulating my topic"},
                    new SelectListItem { Value = "I am just starting my research", Text = "I am just starting my research"},
                    new SelectListItem { Value = "I have just started my research but want more information", Text = "I have just started my research but want more information"},
                    new SelectListItem { Value = "I have been researching but want to make sure I have not missed anything", Text = "I have been researching but want to make sure I have not missed anything"},
                };
            }

        }



        public IEnumerable<SelectListItem> referralType
        {

            get
            {
                return new[]
                {
                    new SelectListItem { Value = "Dissertation Chair", Text = "Dissertation Chair"},
                    new SelectListItem { Value = "Instructor", Text = "Instructor"},
                    new SelectListItem { Value = "Academic Advisor", Text = "Academic Advisor"},
                    new SelectListItem { Value = "Library Website", Text = "Library Website"},
                    new SelectListItem { Value = "Librarian", Text = "Librarian"},
               };
            }

        }

       [Required(ErrorMessage = "Day of week required")]
        public string DayOfWeek { get; set; }

        public IEnumerable<SelectListItem> SelectedDay
        {

            get
            {
                return new[]
                {
                    new SelectListItem { Value = "Early Morning", Text = "Early Morning"},
                    new SelectListItem { Value = "Late Morning", Text = "Late Morning"},
                    new SelectListItem { Value = "Early Afternoon", Text = "Early Afternoon"},
                    new SelectListItem { Value = "Late Afternoon", Text = "Late Afternoon"},
                    new SelectListItem { Value = "Evening", Text = "Evening"},
                    new SelectListItem { Value = "Weekend", Text = "Weekend"} 
                };
            }

        }


    }
}