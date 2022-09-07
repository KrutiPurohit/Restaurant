//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.Bills = new HashSet<Bill>();
        }
    
        public int OrderID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int RestaurantID { get; set; }
        public int MenuItemID { get; set; }
        public int ItemQuantity { get; set; }
        public double OrderAmount { get; set; }
        public int DiningTableID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual DiningTable DiningTable { get; set; }
        public virtual RestaurantMenuItem RestaurantMenuItem { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
