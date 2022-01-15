using ModelLayer;
using System.Collections.Generic;

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
            throw new System.NotImplementedException();
        }
    }
}
