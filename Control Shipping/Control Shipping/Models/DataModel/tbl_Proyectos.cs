//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Control_Shipping.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Proyectos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Proyectos()
        {
            this.tbl_Estaciones = new HashSet<tbl_Estaciones>();
            this.tbl_Partes = new HashSet<tbl_Partes>();
        }
    
        public int Id { get; set; }
        public string Proyecto { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public bool Estatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Estaciones> tbl_Estaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Partes> tbl_Partes { get; set; }
    }
}