using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public partial class Equipas
    {
        public Equipas()
        {
            this.FuncionariosEquipas = new HashSet<FuncionariosEquipas>();
            this.IntervencoesEquipas = new HashSet<IntervencoesEquipas>();
        }

        public int id { get; set; }
        public string localizacao { get; set; }
        public int numElementos { get; set; }

        public virtual ICollection<FuncionariosEquipas> FuncionariosEquipas { get; set; }
        public virtual ICollection<IntervencoesEquipas> IntervencoesEquipas { get; set; }
    }
}
