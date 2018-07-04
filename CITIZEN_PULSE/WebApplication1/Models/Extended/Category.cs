using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.ComponentModel.DataAnnotations;




namespace WebApplication1.Models
{

    [MetadataType(typeof(CategoryMetaData))]

    public partial class Category
    {
    }

    public class CategoryMetaData
    {


        [Display(Name = "Enter Category name")]

        [Required(AllowEmptyStrings = false, ErrorMessage = "date is required")]
        public string Cat_Name { get; set; }





        [Display(Name = "Enter Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "date is required")]
        public Nullable<System.DateTime> Cat_createdon { get; set; }


    }

}