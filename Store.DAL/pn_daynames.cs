//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Store.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class pn_daynames
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pn_daynames()
        {
            this.routine = new HashSet<routine>();
        }
    
        public short id { get; set; }
        public string name { get; set; }
        public Nullable<int> countday { get; set; }
        public Nullable<int> orderby { get; set; }
        public string short_name { get; set; }
        public string days { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<routine> routine { get; set; }
    }
}
