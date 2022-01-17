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
    }
}
