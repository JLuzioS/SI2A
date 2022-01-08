using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public partial class PrecosActivos
    {
        public int activo { get; set; }
        public System.DateTime dtAtualizacao { get; set; }
        public decimal preco { get; set; }

        public virtual Activos Activos { get; set; }
    }
}
