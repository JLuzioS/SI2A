using System.Collections.Generic;

namespace ModelLayer
{
    public interface IDataBase
    {
        bool CreateFuncionario(Funcionarios funcionario);
        List<Funcionarios> GetAllFuncionarios();
        List<Competencias> GetAllCompetencias();
        List<Intervencoes> GetAllIntervencoes();
        bool AddFuncionario(Equipas equipa, Funcionarios funcionario);
        bool DeleteFuncionario(Equipas equipa, Funcionarios funcionario);
        int GetFreeEquipa(int competenciaId);
        bool CreateEquipa(string localizacao, int numElementos);
        bool CreateIntervencao(Intervencoes intervencoes);
        List<Activos> GetAllActivos();
        Activos GetActivo(int activo);
        bool CreateIntervencaoProcedure(Intervencoes intervencoes);
        Funcionarios GetFuncionarios(int idFuncionario);
        Equipas GetEquipas(int idEquipa);
    }
}
