//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DealOffer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DealOffer()
        {
            this.Deal = new HashSet<Deal>();
            this.Deal1 = new HashSet<Deal>();
        }
    
        public int DealOfferID { get; set; }
        public string Currency { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> Weight { get; set; }
        public string ArrivalCity { get; set; }
        public string DepartureCity { get; set; }
        public Nullable<System.TimeSpan> ArrivalTime { get; set; }
        public Nullable<System.TimeSpan> DepartureTime { get; set; }
        public Nullable<System.DateTime> ArrivalDate { get; set; }
        public Nullable<System.DateTime> DepartureDate { get; set; }
        public string ReceiveMethod { get; set; }
        public string DeliveryMethod { get; set; }
        public Nullable<bool> Flexibility { get; set; }
        public Nullable<int> UserID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deal> Deal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deal> Deal1 { get; set; }
        public virtual user user { get; set; }
    }
}
