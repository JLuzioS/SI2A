using System.Collections.Generic;

namespace ModelLayer
{
    public interface IDataBase
    {
        bool CreateFuncionario(Funcionarios funcionario);
        List<Funcionarios> GetAllFuncionarios();
        List<Competencias> GetAllCompetencias();
        List<Intervencoes> GetAllIntervencoes();
        int GetFreeEquipa(int competenciaId);
        bool CreateEquipa(string localizacao, int numElementos);
        bool CreateIntervencao(Intervencoes intervencoes);
        List<Activos> GetAllActivos();
        Activos GetActivo(int activo);
        bool CreateIntervencaoProcedure(Intervencoes intervencoes);
    }
}
