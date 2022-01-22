using AdoNETLayer.concrete;
using AdoNETLayer.dal;
using BusinessLayer;
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
        private IntervencoesEquipasMapper intervencoesEquipasMapper;

        public AdoNet(IContext ctx)
        {
            funcionarioMapper = new FuncionarioMapper(ctx);
            competenciaMapper = new CompetenciaMapper(ctx);
            intervencoesMapper = new IntervencoesMapper(ctx);
            equipasMapper = new EquipasMapper(ctx);
            activosMapper = new ActivosMapper(ctx);
            intervencoesEquipasMapper = new IntervencoesEquipasMapper(ctx);
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

        public bool CreateEquipa(string localizacao, int numElementos)
        {
            try
            {
                equipasMapper.CreateEquipa(localizacao, numElementos);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Activos GetActivo(int activo)
        {
            return activosMapper.Read(activo);
        }

        public int CreateIntervencaoProcedure(Intervencoes intervencoes)
        {
            return intervencoesMapper.CreateWithProcedure(intervencoes);
        }

        public bool AddFuncionario(Equipas equipa, Funcionarios funcionario)
        {
            try
            {
                equipasMapper.AddFuncionario(equipa, funcionario);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteFuncionario(Equipas equipa, Funcionarios funcionario)
        {

            equipasMapper.DeleteFuncionario(equipa, funcionario);
            return true;
        }

        public Funcionarios GetFuncionarios(int idFuncionario)
        {
            return funcionarioMapper.Read(idFuncionario);
        }

        public Equipas GetEquipas(int idEquipa)
        {
            return equipasMapper.Read(idEquipa);
        }

        public List<listAllIntervencoesFromDate_Result> GetALLIntervYear(string anoIntervencao)
        {
            return intervencoesMapper.GetALLIntervYear(anoIntervencao);
        }

        public bool UpdateIntervencao(Intervencoes intervencoes)
        {
            try
            {
                intervencoesMapper.Update(intervencoes);
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public bool AddEquipaToIntervencao(IntervencoesEquipas intervencoesEquipas)
        {
            try
            {
                intervencoesEquipasMapper.AddEquipaToIntervencao(intervencoesEquipas);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateIntervencaoState(Intervencoes intervencoes)
        {
            return intervencoesMapper.UpdateIntervencaoState(intervencoes);
        }
    }
}
