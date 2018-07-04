using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebApplication1.Models
{
    [MetadataType(typeof(surveyMetaData))]

    public partial class Survey
    {
        internal void AddQuestion(IList<Question> list)
        {
           // throw new NotImplementedException();
        }
    }


    //   public enum status
    // {
    //   pending,active,complete
    //}
    public class surveyMetaData
    {


        [Display(Name = "Survey name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "name field  is required")]
        public string Name { get; set; }


        //[Display(Name = "Survey Duration")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "duration field  is required")]
        //public int Duration_days_ { get; set; }

        [Display(Name = "Enter Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "date is required")]
        public System.DateTime Sur_createdon { get; set; }

        //[Display(Name = "Status")]

        //[Required(AllowEmptyStrings = false, ErrorMessage = "status  field  is required")]

        //public string status { get; set; }





    }
}