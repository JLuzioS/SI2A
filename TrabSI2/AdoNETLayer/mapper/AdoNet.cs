﻿using AdoNETLayer.concrete;
using AdoNETLayer.dal;
using ModelLayer;
using System;
using System.Collections.Generic;

namespace AdoNETLayer
{
    public class AdoNet : IDataBase
    {
        private FuncionarioMapper funcionarioMapper;
        private CompetenciaMapper competenciaMapper;
        private IntervencoesMapper intervencoesMapper;
        private EquipasMapper equipasMapper;
        private ActivosMapper activosMapper;

        public AdoNet(IContext ctx)
        {
            funcionarioMapper = new FuncionarioMapper(ctx);
            competenciaMapper = new CompetenciaMapper(ctx);
            intervencoesMapper = new IntervencoesMapper(ctx);
            equipasMapper = new EquipasMapper(ctx);
            activosMapper = new ActivosMapper(ctx);
        }

        public bool CreateFuncionario(Funcionarios funcionario)
        {
            try
            {
                funcionarioMapper.Create(funcionario);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Funcionarios> GetAllFuncionarios()
        {
            return funcionarioMapper.ReadAll();
        }

        public List<Competencias> GetAllCompetencias()
        {
            return competenciaMapper.ReadAll();
        }

        public int GetFreeEquipa(int competenciaId)
        {
            return equipasMapper.GetFreeEquipa(competenciaId);
        }

        public List<Intervencoes> GetAllIntervencoes()
        {
            return intervencoesMapper.ReadAll();
        }

        public bool CreateIntervencao(Intervencoes intervencoes)
        {
            try
            {
                intervencoesMapper.Create(intervencoes);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Activos> GetAllActivos()
        {
            return activosMapper.ReadAll();
        }
    }
}
