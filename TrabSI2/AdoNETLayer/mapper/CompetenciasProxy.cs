using AdoNETLayer.dal;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNETLayer.mapper
{
    class CompetenciasProxy : Competencias
    {
        public CompetenciasProxy(Competencias competencia) : base()
        {
            base.id = competencia.id;
            base.descricao = competencia.descricao;
        }
    }
}
