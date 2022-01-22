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

        public int CreateFuncionario(Funcionarios funcionario)
        {
            return funcionarioMapper.Create(funcionario).id;
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
            intervencoesMapper.Create(intervencoes);
            return true;
        }

        public List<Activos> GetAllActivos()
        {
            return activosMapper.ReadAll();
        }

        public int CreateEquipa(string localizacao, int numElementos)
        {
            return equipasMapper.CreateEquipa(localizacao, numElementos);
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
            equipasMapper.AddFuncionario(equipa, funcionario);
            return true;
        }

        public int DeleteFuncionario(Equipas equipa, Funcionarios funcionario)
        {
            return equipasMapper.DeleteFuncionario(equipa, funcionario);
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
            intervencoesMapper.Update(intervencoes);
            return true; return false;
        }

        public bool AddEquipaToIntervencao(IntervencoesEquipas intervencoesEquipas)
        {
            intervencoesEquipasMapper.AddEquipaToIntervencao(intervencoesEquipas);
            return true;
        }

        public bool UpdateIntervencaoState(Intervencoes intervencoes)
        {
            return intervencoesMapper.UpdateIntervencaoState(intervencoes);
        }

        public void RemoveFuncionario(Funcionarios func)
        {
            funcionarioMapper.Delete(func);
        }

        public void RemoveEquipa(Equipas equipa)
        {
            equipasMapper.Delete(equipa);
        }

        public int ChangeFuncionarioCompetencia(Funcionarios funcionario1, Funcionarios funcionario2)
        {
            throw new Exception("Opção implementada apenas em Entity Framework");
        }
    }
}
