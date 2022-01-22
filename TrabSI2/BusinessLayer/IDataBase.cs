using ModelLayer;
using System.Collections.Generic;

namespace BusinessLayer
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
        bool AddEquipaToIntervencao(IntervencoesEquipas entity);
        List<Activos> GetAllActivos();
        Activos GetActivo(int activo);
        int CreateIntervencaoProcedure(Intervencoes intervencoes);
        Funcionarios GetFuncionarios(int idFuncionario);
        Equipas GetEquipas(int idEquipa);
        List<listAllIntervencoesFromDate_Result> GetALLIntervYear(string anoIntervencao);
        bool UpdateIntervencaoState(Intervencoes intervencoes);
    }
}
