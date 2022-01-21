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
        bool CreateIntervencao(Intervencoes intervencoes);
        List<Activos> GetAllActivos();
    }
}
