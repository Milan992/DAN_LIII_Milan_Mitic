//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfHotel.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblEmployee
    {
        public int EmployeeID { get; set; }
        public int AccountID { get; set; }
        public Nullable<int> HotelFloor { get; set; }
        public string Gender { get; set; }
        public string Cityzenship { get; set; }
        public int EngagementID { get; set; }
        public Nullable<int> Salary { get; set; }
    
        public virtual tblAccount tblAccount { get; set; }
        public virtual tblEngagement tblEngagement { get; set; }
    }
}
