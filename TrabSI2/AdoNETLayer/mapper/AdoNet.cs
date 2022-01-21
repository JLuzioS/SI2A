using AdoNETLayer.concrete;
using AdoNETLayer.dal;
using ModelLayer;
using System;
using System.Collections.Generic;

namespace AdoNETLayer
{
    public class AdoNet : IDataBase
    {

        private IContext ctx;
        private FuncionarioMapper funcionarioMapper;
        private CompetenciaMapper competenciaMapper;
        private IntervencoesMapper intervencoesMapper;

        public AdoNet(IContext ctx)
        {
            this.ctx = ctx;
            funcionarioMapper = new FuncionarioMapper(ctx);
            competenciaMapper = new CompetenciaMapper(ctx); 
            intervencoesMapper = new IntervencoesMapper(ctx);
        }

        public bool CreateFuncionario(Funcionarios funcionario)
        {
            try
            {
                funcionarioMapper.Create(funcionario);
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public List<Funcionarios> GetAllFuncionarios()
        {
            return funcionarioMapper.GetAllFuncionarios();
        }

        public List<Competencias> GetAllCompetencias()
        {
            return competenciaMapper.GetAllCompetencias();
        }

        public int GetFreeEquipa(int competenciaId)
        {
            return competenciaMapper.GetFreeEquipa(competenciaId);
        }

        public List<Intervencoes> GetAllIntervencoes()
        {
            return intervencoesMapper.GetAllInternvencoes(); 
        }
    }
}
