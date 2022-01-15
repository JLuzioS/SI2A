using DataLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Services
    {
        

        private IDataBase dataBase;


        public Services(IDataBase db)
        {
            dataBase = db;
        }

        public bool CreateFuncionario(ModelLayer.Funcionarios funcionario)
        {
            return dataBase.CreateFuncionario(funcionario);
        }
    }
}
