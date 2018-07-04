//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question()
        {
            this.options = new HashSet<option>();
            this.Sur_answer = new HashSet<Sur_answer>();
        }
    
        public int Questionid { get; set; }
        public int SurveyId { get; set; }
        public string Q_text { get; set; }
        public Nullable<int> order { get; set; }
        public Nullable<bool> Isdeleted { get; set; }
        public int typeId { get; set; }
        public int customerId { get; set; }
        public Nullable<System.DateTime> Q_createdon { get; set; }
    
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<option> options { get; set; }
        public virtual Survey Survey { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sur_answer> Sur_answer { get; set; }
    }
}
