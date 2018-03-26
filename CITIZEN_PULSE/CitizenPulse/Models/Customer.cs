using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    [MetadataType(typeof(CustomerMetaData))]

    public partial class Customer
    {
        internal static object ToList()
        {
            throw new NotImplementedException();
        }
    }
    public class CustomerMetaData
    {

        [Display(Name = "Occupation")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "occupation field  is required")]
        public string occupation { get; set; }

        [Display(Name = "Enter Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:MM/dd/yyyy}")]
      [Required(AllowEmptyStrings = false, ErrorMessage = "date is required")]
        public Nullable<System.DateTime> createdOn { get; set; }


    }

}