using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;




namespace WebApplication1.Models
{

    [MetadataType(typeof(optionsMetaData))]

    public partial class option
    {
    }

    public class optionsMetaData
    {


        [Display(Name = "Enter option text")]

        [Required(AllowEmptyStrings = false, ErrorMessage = "date is required")]
        public string op_text { get; set; }


        //[Display(Name = "option deleted")]

        //[Required(AllowEmptyStrings = false, ErrorMessage = "date is required")]

        //public Nullable<bool> op_isdeleted { get; set; }


        [Display(Name = "Enter Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "date is required")]
        public Nullable<System.DateTime> op_createdon { get; set; }

    }


}