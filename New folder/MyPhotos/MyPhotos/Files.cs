//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyPhotos
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(IsReference = true)]
    public partial class Files
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Files()
        {
            this.Properties = new HashSet<Properties>();
            this.Persons = new HashSet<Persons>();
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string abs_path { get; set; }

        [DataMember]
        public string created_date { get; set; }

        [DataMember]
        public string @event { get; set; }

        [DataMember]
        public string event_date { get; set; }

        [DataMember]
        public string event_location { get; set; }

        [DataMember]
        public string description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Properties> Properties { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        [DataMember]
        public virtual ICollection<Persons> Persons { get; set; }
    }
}