using ModelLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IDataBase
    {
        int CreateFuncionario(Funcionarios funcionario);
        List<Funcionarios> GetAllFuncionarios();
        List<Competencias> GetAllCompetencias();
        List<Intervencoes> GetAllIntervencoes();
        bool AddFuncionario(Equipas equipa, Funcionarios funcionario);
        int DeleteFuncionario(Equipas equipa, Funcionarios funcionario);
        int GetFreeEquipa(int competenciaId);
        int CreateEquipa(string localizacao, int numElementos);
        bool CreateIntervencao(Intervencoes intervencoes);
        bool AddEquipaToIntervencao(IntervencoesEquipas entity);
        List<Activos> GetAllActivos();
        Activos GetActivo(int activo);
        int CreateIntervencaoProcedure(Intervencoes intervencoes);
        Funcionarios GetFuncionarios(int idFuncionario);
        Equipas GetEquipas(int idEquipa);
        List<listAllIntervencoesFromDate_Result> GetALLIntervYear(string anoIntervencao);
        bool UpdateIntervencaoState(Intervencoes intervencoes);
        void RemoveFuncionario(Funcionarios func);
        void RemoveEquipa(Equipas equipa);
        int ChangeFuncionarioCompetencia(Funcionarios funcionario1, Funcionarios funcionario2);
    }
}
