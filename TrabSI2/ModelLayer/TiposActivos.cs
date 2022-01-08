using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public partial class TiposActivos
    {
        public TiposActivos()
        {
            this.Activos = new HashSet<Activos>();
        }

        public int id { get; set; }
        public string descricao { get; set; }

        public virtual ICollection<Activos> Activos { get; set; }
    }
}
