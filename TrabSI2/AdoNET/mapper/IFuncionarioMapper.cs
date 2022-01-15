using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNET.mapper
{
    interface IFuncionariosMapper : IMapper<Funcionarios, int?, List<Funcionarios>>
    {
    }
}
