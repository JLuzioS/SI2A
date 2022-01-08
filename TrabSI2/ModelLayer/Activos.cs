using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public partial class Activos
    {
        public Activos()
        {
            this.Intervencoes = new HashSet<Intervencoes>();
            this.PrecosActivos = new HashSet<PrecosActivos>();
            this.Activos1 = new HashSet<Activos>();
            this.Activos2 = new HashSet<Activos>();
        }

        public int id { get; set; }
        public string nome { get; set; }
        public System.DateTime dtAaquisicao { get; set; }
        public byte estado { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string localizacao { get; set; }
        public int funcionario { get; set; }
        public int tipo { get; set; }

        public virtual Funcionarios Funcionarios { get; set; }
        public virtual TiposActivos TiposActivos { get; set; }
        public virtual ICollection<Intervencoes> Intervencoes { get; set; }
        public virtual ICollection<PrecosActivos> PrecosActivos { get; set; }
        public virtual ICollection<Activos> Activos1 { get; set; }
        public virtual ICollection<Activos> Activos2 { get; set; }
    }
}
