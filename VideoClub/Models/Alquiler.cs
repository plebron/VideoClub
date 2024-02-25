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
    
    public partial class Alquiler
    {
        public string AlquilerID { get; set; }
        public string PeliculaID { get; set; }
        public string ClienteID { get; set; }
        public Nullable<System.DateTime> FechaEntrega { get; set; }
        public Nullable<System.DateTime> FechaDevolucion { get; set; }
        public Nullable<int> DiasExtra { get; set; }
        public Nullable<decimal> Penalizacion { get; set; }
        public Nullable<decimal> TotalPagar { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Pelicula Pelicula { get; set; }
    }
}
