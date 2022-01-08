using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public partial class IntervencoesEquipas
    {
        public int equipa { get; set; }
        public int intervencao { get; set; }
        public System.DateTime dtAtribuicao { get; set; }
        public Nullable<System.DateTime> dtDispensa { get; set; }

        public virtual Equipas Equipas { get; set; }
        public virtual Intervencoes Intervencoes { get; set; }
    }
}
