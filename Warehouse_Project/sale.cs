//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Warehouse_Project
{
    using System;
    using System.Collections.Generic;
    
    public partial class sale
    {
        public int ID { get; set; }
        public Nullable<int> s_good { get; set; }
        public Nullable<int> s_customer { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<System.DateTime> date { get; set; }
    
        public virtual customer customer { get; set; }
        public virtual goods goods { get; set; }
    }
}