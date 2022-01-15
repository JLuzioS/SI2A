using AdoNET.dal;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNET.concrete
{
    class FuncionarioRepository
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
