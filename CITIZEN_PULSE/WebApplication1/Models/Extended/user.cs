using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication1.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
       

        public string ConfirmPassword { get; set; }
    }

    public enum gender
    {
        male=4,
        female=5
    }
    public enum Role
    {
        SA=1,CA=2,NONE=3
    }
    public class UserMetadata
    {
        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "first name is required")]
               

        public string fname { get; set; }

        [Display(Name = "Last name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "last name is required")]
        


        public string Lname { get; set; }

        [Display(Name = "Email id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "email is required")]
        [DataType(DataType.EmailAddress)]

       

        public string email { get; set; }

        
        [Required(AllowEmptyStrings = false, ErrorMessage = "passwaord is required")]
        [DataType(DataType.Password)]
        
        [MinLength(3,ErrorMessage ="minimum 3 characters required")]
       
  
        public string password { get; set; }

        [Display(Name = "Confirmed passwaord")]
        [Required(AllowEmptyStrings = false, ErrorMessage = " confirm your passwaord")]
        [Compare("password", ErrorMessage = "Confirm password doesn't match, Type again !")]

        public string ConfirmPassword { get; set; }




        [Display(Name = "Role")]
        public Role Role { get; set; }

        [Display(Name = "Gender")]

        public gender gender { get; set; }



    }

}