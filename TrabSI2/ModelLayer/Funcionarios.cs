using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public partial class Funcionarios
    {
        public Funcionarios()
        {
            this.Activos = new HashSet<Activos>();
            this.FuncionariosEquipas = new HashSet<FuncionariosEquipas>();
            this.Competencias = new HashSet<Competencias>();
        }

        public int id { get; set; }
        public string cc { get; set; }
        public string nif { get; set; }
        public string nome { get; set; }
        public System.DateTime dtNascimento { get; set; }
        public string morada { get; set; }
        public string codigoPostal { get; set; }
        public string localidade { get; set; }
        public int profissao { get; set; }
        public string telefone { get; set; }
        public string telemovel { get; set; }

        public virtual ICollection<Activos> Activos { get; set; }
        public virtual Profissoes Profissoes { get; set; }
        public virtual ICollection<FuncionariosEquipas> FuncionariosEquipas { get; set; }
        public virtual ICollection<Competencias> Competencias { get; set; }
    }
}
