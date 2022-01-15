//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Activos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Activos()
        {
            this.Intervencoes = new HashSet<Intervencoes>();
            this.PrecosActivos = new HashSet<PrecosActivos>();
            this.Activos1 = new HashSet<Activos>();
            this.Activos2 = new HashSet<Activos>();
        }
    
        public int id { get; set; }
        public string nome { get; set; }
        public System.DateTime dtAaquisicao { get; set; }
        public byte estado { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string localizacao { get; set; }
        public int funcionario { get; set; }
        public int tipo { get; set; }
    
        public virtual Funcionarios Funcionarios { get; set; }
        public virtual TiposActivos TiposActivos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Intervencoes> Intervencoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrecosActivos> PrecosActivos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activos> Activos1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activos> Activos2 { get; set; }
    }
}
