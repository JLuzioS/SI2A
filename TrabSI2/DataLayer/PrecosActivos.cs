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
    
    public partial class PrecosActivos
    {
        public int activo { get; set; }
        public System.DateTime dtAtualizacao { get; set; }
        public decimal preco { get; set; }
    
        public virtual Activos Activos { get; set; }
    }
}
