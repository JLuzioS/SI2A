using AdoNET.mapper;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AdoNET.concrete
{
    class FuncionarioMapper :AbstracMapper<Funcionarios, int, List<Funcionarios>>,  IFuncionariosMapper
    {


        
        public Funcionarios Create(Funcionarios entity)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                using ()
            }
        }

        public Funcionarios Delete(Funcionarios entity)
        {
            throw new NotImplementedException();
        }

        public Funcionarios Read(int id)
        {
            throw new NotImplementedException();
        }

        public Funcionarios Read(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Funcionarios> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Funcionarios Update(Funcionarios entity)
        {
            throw new NotImplementedException();
        }
    }
}
