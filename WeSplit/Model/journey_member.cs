//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeSplit.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class journey_member
    {
        public int id { get; set; }
        public int journey_id { get; set; }
        public int member_id { get; set; }
        public Nullable<double> journey_member_money { get; set; }
    
        public virtual journey journey { get; set; }
        public virtual member member { get; set; }
    }
}