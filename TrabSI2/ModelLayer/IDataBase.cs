using System.Collections.Generic;

namespace ModelLayer
{
    public interface IDataBase
    {
        bool CreateFuncionario(Funcionarios funcionario);
        List<Funcionarios> GetAllFuncionarios();
        List<Competencias> GetAllCompetencias();
        List<Intervencoes> GetAllIntervencoes();
        Equipas AddFuncionario(Equipas equipa, Funcionarios funcionario);
        Equipas DeleteFuncionario(Equipas equipa, Funcionarios funcionario);
        int GetFreeEquipa(int competenciaId);
        bool CreateIntervencao(Intervencoes intervencoes);
        List<Activos> GetAllActivos();
        Funcionarios GetFuncionarios(int idFuncionario);
        Equipas GetEquipas(int idEquipa);
    }
}
