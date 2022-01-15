using AdoNETLayer.dal;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNETLayer.concrete
{
    class FuncionarioRepository: IFuncionarioRepository
    {
        private IContext context;
        public FuncionarioRepository(IContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Funcionarios> Find(Func<Funcionarios, bool> criteria)
        {
            //Implementação muito pouco eficiente.  
            return FindAll().Where(criteria);
        }

        public IEnumerable<Funcionarios> FindAll()
        {
            return new FuncionarioMapper(context).ReadAll();
        }
    }
}
