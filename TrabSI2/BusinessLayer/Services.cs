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
        public Equipas GetEquipa(int idEquipa)
        {
            return dataBase.GetEquipas(idEquipa);
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
        public List<Intervencoes> GetAllIntervencoes()
        {
            return dataBase.GetAllIntervencoes();
        }

        public bool CreateIntervencao(Intervencoes intervencoes)
        {
            return dataBase.CreateIntervencao(intervencoes);
        }

        public List<Activos> GetAllActivos()
        {
            return dataBase.GetAllActivos();
        }

        public Equipas AddFuncionarioToEquipa(Equipas equipa, Funcionarios funcionario)
        {
            return dataBase.AddFuncionario(equipa, funcionario);
        }

        public Funcionarios GetFuncionarios(int idFuncionario)
        {
            return dataBase.GetFuncionarios(idFuncionario);
        }

        public Equipas DeleteFuncionarioFromEquipa(Equipas equipa, Funcionarios funcionario)
        {
            return dataBase.DeleteFuncionario(equipa, funcionario);
        }
    }
}
