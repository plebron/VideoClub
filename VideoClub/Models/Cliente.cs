//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VideoClub.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            this.Alquilers = new HashSet<Alquiler>();
        }
    
        public string ClienteID { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public Nullable<int> Telefono { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alquiler> Alquilers { get; set; }
    }
}
