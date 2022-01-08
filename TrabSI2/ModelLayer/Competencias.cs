using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public partial class Competencias
    {
        public Competencias()
        {
            this.Intervencoes = new HashSet<Intervencoes>();
            this.Funcionarios = new HashSet<Funcionarios>();
        }

        public int id { get; set; }
        public string descricao { get; set; }

        public virtual ICollection<Intervencoes> Intervencoes { get; set; }
        public virtual ICollection<Funcionarios> Funcionarios { get; set; }
    }
}
