using ModelLayer;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkLayer
{
    public class EntityFramework : IDataBase
    {
        public bool CreateFuncionario(ModelLayer.Funcionarios funcionario)
        {
            using (var ctx = new L51NG3Entities())
            {
                Funcionarios newFunc = new Funcionarios
                {
                    cc = funcionario.cc,
                    nif = funcionario.nif,
                    nome = funcionario.nome,
                    dtNascimento = funcionario.dtNascimento,
                    morada = funcionario.morada,
                    codigoPostal = funcionario.codigoPostal,
                    localidade = funcionario.localidade,
                    profissao = funcionario.profissao,
                    telefone = funcionario.telefone,
                    telemovel = funcionario.telemovel
                };

                ctx.SaveChanges();
            }
            return false;
        }

        public List<ModelLayer.Competencias> GetAllCompetencias()
        {
            using (var ctx = new L51NG3Entities())
            {
                var EFcompetencias = from allComp in ctx.Competencias select allComp;

                var ModelComp = new List<ModelLayer.Competencias>();

                foreach (var EFcomp in EFcompetencias)
                {
                    ModelComp.Add(Map(EFcomp));
                }

                return ModelComp;
            }
        }

        private ModelLayer.Competencias Map(Competencias entityFrameWorkCompetencia)
        {
            return new ModelLayer.Competencias
            {
                id = entityFrameWorkCompetencia.id,
                descricao = entityFrameWorkCompetencia.descricao
            };
        }

        public List<ModelLayer.Funcionarios> GetAllFuncionarios()
        {
            using (var ctx = new L51NG3Entities())
            {
                var EFfuncionarios = from allFunc in ctx.Funcionarios select allFunc;

                var ModelFunc = new List<ModelLayer.Funcionarios>();

                foreach(var EFfunc in EFfuncionarios)
                {
                    ModelFunc.Add(Map(EFfunc));
                }

                return ModelFunc;
            }
        }

        public int GetFreeEquipa(int competenciaId)
        {
            throw new System.NotImplementedException();
        }

        public ModelLayer.Funcionarios Map(Funcionarios entityFrameWorkFuncionario)
        {
            return new ModelLayer.Funcionarios
            {
                cc = entityFrameWorkFuncionario.cc,
                nif = entityFrameWorkFuncionario.nif,
                nome = entityFrameWorkFuncionario.nome,
                dtNascimento = entityFrameWorkFuncionario.dtNascimento,
                morada = entityFrameWorkFuncionario.morada,
                codigoPostal = entityFrameWorkFuncionario.codigoPostal,
                localidade = entityFrameWorkFuncionario.localidade,
                profissao = entityFrameWorkFuncionario.profissao,
                telefone = entityFrameWorkFuncionario.telefone,
                telemovel = entityFrameWorkFuncionario.telemovel
            };
        }

        public List<ModelLayer.Intervencoes> GetAllIntervencoes()
        {
            throw new System.NotImplementedException();
        }

        public bool CreateEquipa(string localizacao, int numElementos)
        {
            throw new System.NotImplementedException();
        }

        public bool CreateIntervencao(ModelLayer.Intervencoes intervencoes)
        {
            throw new System.NotImplementedException();
        }

        public List<ModelLayer.Activos> GetAllActivos()
        {
            throw new System.NotImplementedException();
        }
    }
}
