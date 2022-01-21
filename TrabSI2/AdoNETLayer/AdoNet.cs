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

        public AdoNet(IContext ctx)
        {
            this.ctx = ctx;
        }

        public bool CreateFuncionario(Funcionarios funcionario)
        {
            try
            {
                FuncionarioMapper mapper = new FuncionarioMapper(ctx);
                mapper.Create(funcionario);
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public List<Funcionarios> GetAllFuncionarios()
        {
            FuncionarioMapper mapper = new FuncionarioMapper(ctx);
            return mapper.GetAllFuncionarios();
        }

        public List<Competencias> GetAllCompetencias()
        {
            CompetenciaMapper mapper = new CompetenciaMapper(ctx);
            return mapper.GetAllCompetencias();

        }

        public int GetFreeEquipa(int competenciaId)
        {
            CompetenciaMapper mapper = new CompetenciaMapper(ctx);
            return mapper.GetFreeEquipa(competenciaId);
        }
    }
}
