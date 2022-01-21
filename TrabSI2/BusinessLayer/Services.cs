using ModelLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class Services
    {
        

        private IDataBase dataBase;


        public Services(IDataBase db)
        {
            dataBase = db;
        }

        public bool CreateFuncionario(Funcionarios funcionario)
        {
            return dataBase.CreateFuncionario(funcionario);
        }

        public List<Funcionarios> GetAllFuncionarios()
        {
            return dataBase.GetAllFuncionarios();
        }

        public List<Competencias> GetAllCompetencias()
        {
            return dataBase.GetAllCompetencias();
        }

        public int GetFreeEquipa(int competenciaId)
        {
            return dataBase.GetFreeEquipa(competenciaId);
        }
    }
}
