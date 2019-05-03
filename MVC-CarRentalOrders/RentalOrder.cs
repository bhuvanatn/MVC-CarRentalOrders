//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_CarRentalOrders
{
    using System;
    using System.Collections.Generic;
    
    public partial class RentalOrder
    {
        public int Id { get; set; }
        public System.DateTime DateProcessed { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public System.DateTime RentStartDate { get; set; }
        public System.DateTime RentEndDate { get; set; }
        public int Days { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
