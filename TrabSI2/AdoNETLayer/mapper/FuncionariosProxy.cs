using AdoNETLayer.dal;
using ModelLayer;

namespace AdoNETLayer.mapper
{
    class FuncionariosProxy : Funcionarios
    {
        public FuncionariosProxy(Funcionarios funcionario) : base()
        {
            base.cc = funcionario.cc;
            base.nif = funcionario.nif;
            base.nome = funcionario.nome;
            base.dtNascimento = funcionario.dtNascimento;
            base.morada = funcionario.morada;
            base.codigoPostal = funcionario.codigoPostal;
            base.localidade = funcionario.localidade;
            base.profissao = funcionario.profissao;
            base.telefone = funcionario.telefone;
            base.telemovel = funcionario.telemovel;
        }
    }
}
