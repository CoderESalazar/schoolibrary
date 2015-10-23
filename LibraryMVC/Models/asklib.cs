using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LibraryMVC4.Models
{
    public class asklib : admin
    {
       //This class inherits from admin. 
        public Boolean ViewedMess { get; set; }
        public string GetMailCount { get; set; }            

     
    }
}