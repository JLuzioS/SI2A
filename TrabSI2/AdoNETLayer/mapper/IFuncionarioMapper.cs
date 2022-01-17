using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNETLayer.mapper
{
    public interface IFuncionariosMapper : IMapper<Funcionarios, int?, List<Funcionarios>>
    {
    }
}
