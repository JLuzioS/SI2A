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
    
    public partial class Funcionarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Funcionarios()
        {
            this.Activos = new HashSet<Activos>();
            this.FuncionariosEquipas = new HashSet<FuncionariosEquipas>();
            this.Competencias = new HashSet<Competencias>();
        }
    
        public int id { get; set; }
        public string cc { get; set; }
        public string nif { get; set; }
        public string nome { get; set; }
        public System.DateTime dtNascimento { get; set; }
        public string morada { get; set; }
        public string codigoPostal { get; set; }
        public string localidade { get; set; }
        public int profissao { get; set; }
        public string telefone { get; set; }
        public string telemovel { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activos> Activos { get; set; }
        public virtual Profissoes Profissoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FuncionariosEquipas> FuncionariosEquipas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Competencias> Competencias { get; set; }
    }
}
