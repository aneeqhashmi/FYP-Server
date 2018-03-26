using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebApplication1.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class user
    {
        


        public string ConfirmPassword { get; set; }
    }

    public enum gender
    {
        male,female
    }
    public enum Role
    {
        SA,CA,NONE
    }
    public class UserMetadata
    {
        [Display(Name = "First Nmae")]
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
        public string ConfirmPassword { get; set; }




        [Display(Name = "Role")]
        public Role Role { get; set; }

        [Display(Name = "Gender")]

        public gender gender { get; set; }



    }

}