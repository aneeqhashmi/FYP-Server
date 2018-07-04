using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [MetadataType(typeof(QuestionMetaData))]

    public  partial class Question
    {


    }

    public class QuestionMetaData
    {

        [Display(Name = "Question text")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "occupation field  is required")]
        public string Q_text { get; set; }


        [Display(Name = "Question_order")]

        [Required(AllowEmptyStrings = false, ErrorMessage = "Order is required")]
        public Nullable<int> order { get; set; }

        //[Display(Name = "type of question")]

        //[Required(AllowEmptyStrings = false, ErrorMessage = "date is required")]

        //public int typeId { get; set; }


        [Display(Name = "Enter Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "date is required")]
        public Nullable<System.DateTime> Q_createdon { get; set; }

    }

}

