using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;




namespace WebApplication1.Models
{

    [MetadataType(typeof(SurResponseMetaData))]

    public partial class sur_response
    {
    }

    public class SurResponseMetaData
    {

        [Display(Name = "Enter Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "date is required")]
        public System.DateTime Respondon { get; set; }


    }


}