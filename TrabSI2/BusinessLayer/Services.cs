using ModelLayer;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace BusinessLayer
{
    public class Services
    {
        private IDataBase dataBase;

        public Services(IDataBase db)
        {
            dataBase = db;
        }
        public int CreateFuncionario(Funcionarios funcionario)
        {
            return dataBase.CreateFuncionario(funcionario);
        }
        public List<Funcionarios> GetAllFuncionarios()
        {
            return dataBase.GetAllFuncionarios();
        }
        public List<Competencias> GetAllCompetencias()
        {
            return dataBase.GetAllCompetencias();
        }
        public int GetFreeEquipa(int competenciaId)
        {
            return dataBase.GetFreeEquipa(competenciaId);
        }
        public List<Intervencoes> GetAllIntervencoes()
        {
            return dataBase.GetAllIntervencoes();
        }

        public bool CreateIntervencao(Intervencoes intervencoes)
        {
            Activos activo = dataBase.GetActivo(intervencoes.activo);
            if (activo.dtAaquisicao > intervencoes.dtInicio)
                throw new Exception("Data de inicio da intervenção é inferior à data de acquisição do Activo");
            return dataBase.CreateIntervencao(intervencoes);
        }

        public int CreateIntervencaoProcedure(Intervencoes intervencoes)
        {
            return dataBase.CreateIntervencaoProcedure(intervencoes);
        }

        public List<Activos> GetAllActivos()
        {
            return dataBase.GetAllActivos();
        }
        public int CreateEquipa(string localizacao, int numElementos)
        {
            return dataBase.CreateEquipa(localizacao, numElementos);
        }

        public bool AddFuncionarioToEquipa(Equipas equipa, Funcionarios funcionario)
        {
            return dataBase.AddFuncionario(equipa, funcionario);
        }

        public Equipas GetEquipa(int idEquipa)
        {
            return dataBase.GetEquipas(idEquipa);
        }

        public Funcionarios GetFuncionarios(int idFuncionario)
        {
            return dataBase.GetFuncionarios(idFuncionario);
        }

        public void DeleteFuncionarioFromEquipa(Equipas equipa, Funcionarios funcionario)
        {
            int numrows = dataBase.DeleteFuncionario(equipa, funcionario);
            if (numrows <= 0)
            {
                throw new Exception("Houve um erro a remover o funcionario à equipa");
            }
        }


        public bool CreateAndAttributeIntervencaoToEquipa(Intervencoes intervencoes) {
            /* (e) Obter o codigo de uma equipa livre, dada uma descricao de intervencao, capaz de
                resolver o problema. Em caso de haver varias equipas deve escolher-se a que teve uma
                intervencao atribuıda a mais tempo  */

            /*(f) Criar o procedimento p criaInter que permite criar uma intervencao */

            /*(j) Actualizar o estado de uma intervencao*/

            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                int equipa = GetFreeEquipa(intervencoes.competencias);
                if(equipa <= 0)
                {
                    throw new Exception("Nao existem equipas disponiveis para a competencia introduzida.");
                }
                int id = dataBase.CreateIntervencaoProcedure(intervencoes);
                if (id != -1) 
                {
                    intervencoes.id = id;
                    IntervencoesEquipas intervencoesEquipas = new IntervencoesEquipas
                    {
                        equipa = equipa,
                        intervencao = intervencoes.id,
                        dtAtribuicao = DateTime.Now
                    };

                    if(dataBase.AddEquipaToIntervencao(intervencoesEquipas))
                    {
                        intervencoes.estado = "Em Análise";
                        
                        if(dataBase.UpdateIntervencaoState(intervencoes))
                        {
                            ts.Complete();
                            return true;
                        }
                        
                    }
                }
                
                return false;
            }
        }

        public List<listAllIntervencoesFromDate_Result> GetALLIntervYear(string anoIntervencao)
        {
            return dataBase.GetALLIntervYear(anoIntervencao);
        }

        public void ChangeFuncionarioCompetencia(Funcionarios funcionario1, Funcionarios funcionario2)
        {
            int numrows = dataBase.ChangeFuncionarioCompetencia(funcionario1, funcionario2);
            if (numrows <= 0)
            {
                throw new Exception("Houve um erro a trocar a competencia entre os dois funcionarios");
            }
        }
    }
}
