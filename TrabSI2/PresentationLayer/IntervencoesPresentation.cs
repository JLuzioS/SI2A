using BusinessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    class IntervencoesPresentation
    {
        private Services service;

        public IntervencoesPresentation(Services service)
        {
            this.service = service;
        }

        public void GetAllIntervencoes()
        {
            foreach (var interv in service.GetAllIntervencoes())
            {
                Console.WriteLine("Intervencao %d Competencia %d", interv.id, interv.competencias);
            }
        }

        public void CreateIntervencao()
        {
            Console.WriteLine("Insira os dados para nova intervenção: ");

            Funcionarios funcionario = new Funcionarios();

            funcionario.cc = GetCC();
            funcionario.nif = GetNIF();
            funcionario.nome = GetName();
            funcionario.dtNascimento = GetBirthDate();
            funcionario.morada = GetAddress();
            funcionario.codigoPostal = GetPostalCode();
            funcionario.localidade = GetTown();
            funcionario.profissao = GetProfession();
            funcionario.telefone = GetPhone();
            funcionario.telemovel = GetCellPhone();

            if (service.CreateFuncionario(funcionario))
            {
                Console.WriteLine("Funcionario criado com sucesso!");
            }
            else
            {
                Console.WriteLine("Algo correu mal! Nao sei");
            }
        }

        private string GetCC()
        {
            Console.WriteLine("CC: ");
            var option = Console.ReadLine();
            // TODO DATA Validation
            return option;
        }

        private string GetNIF()
        {
            Console.WriteLine("NIF: ");
            var option = Console.ReadLine();
            // TODO DATA Validation
            return option;
        }

        private string GetName()
        {
            Console.WriteLine("Nome: ");
            var option = Console.ReadLine();
            // TODO DATA Validation
            return option;
        }

        private DateTime GetBirthDate()
        {
            Console.WriteLine("Data de Nascimento: ");
            var option = Console.ReadLine();
            // TODO DATA Validation
            return default;
        }

        private string GetAddress()
        {
            Console.WriteLine("Morada: ");
            var option = Console.ReadLine();
            // TODO DATA Validation
            return option;
        }

        private string GetPostalCode()
        {
            Console.WriteLine("Codigo de Postal: ");
            var option = Console.ReadLine();
            // TODO DATA Validation
            return option;
        }

        private string GetTown()
        {
            Console.WriteLine("Localidade: ");
            var option = Console.ReadLine();
            // TODO DATA Validation
            return option;
        }

        private int GetProfession()
        {
            Console.WriteLine("Profissao: ");
            var option = Console.ReadLine();
            // TODO DATA Validation
            return Int32.Parse(option);
        }

        private string GetPhone()
        {
            Console.WriteLine("Telefone: ");
            var option = Console.ReadLine();
            // TODO DATA Validation
            return option;
        }

        private string GetCellPhone()
        {
            Console.WriteLine("Telemovel: ");
            var option = Console.ReadLine();
            // TODO DATA Validation
            return option;
        }
    }
}
