using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public partial class FuncionariosEquipas
    {
        public int funcionario { get; set; }
        public int equipa { get; set; }
        public System.DateTime dtEntrada { get; set; }
        public Nullable<System.DateTime> dtSaida { get; set; }

        public virtual Equipas Equipas { get; set; }
        public virtual Funcionarios Funcionarios { get; set; }
    }
}
