using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Userlogin
    {

        [Display(Name = "Email id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "email is required")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "passwaord is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }



    }
}