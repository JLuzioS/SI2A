using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public partial class Profissoes
    {
        public Profissoes()
        {
            this.Funcionarios = new HashSet<Funcionarios>();
        }

        public int id { get; set; }
        public string descricao { get; set; }

        public virtual ICollection<Funcionarios> Funcionarios { get; set; }
    }
}
