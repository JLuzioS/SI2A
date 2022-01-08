using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public partial class Intervencoes
    {
        public Intervencoes()
        {
            this.IntervencoesEquipas = new HashSet<IntervencoesEquipas>();
        }

        public int id { get; set; }
        public int competencias { get; set; }
        public string estado { get; set; }
        public int activo { get; set; }
        public decimal vlMonetario { get; set; }
        public System.DateTime dtInicio { get; set; }
        public Nullable<System.DateTime> dtFim { get; set; }
        public int perMeses { get; set; }

        public virtual Activos Activos { get; set; }
        public virtual Competencias Competencias1 { get; set; }
        public virtual ICollection<IntervencoesEquipas> IntervencoesEquipas { get; set; }
    }
}
