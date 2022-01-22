using BusinessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    class FuncionarioPresentation
    {
        private Services service;

        public FuncionarioPresentation(Services service)
        {
            this.service = service;
        }

        public void GetAllFuncionarios()
        {
            foreach (var fun in service.GetAllFuncionarios())
            {
                Console.WriteLine(fun.nome);
            }
        }

        public void CreateFuncionario()
        {
            Console.WriteLine("Insira os dados do novo Funcionario: ");

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

            if (service.CreateFuncionario(funcionario) > 0)
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

        public void ChangeFuncionarioCompetencia()
        {
            Console.WriteLine("Insira o id do primeiro funcionario: ");
            int idFuncionario1;
            while (true)
            {
                try
                {
                    idFuncionario1 = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Numero de funcionario invalido tente outra vez: ");
                }

            }

            Console.WriteLine("Insira o id do segundo funcionario: ");
            int idFuncionario2;
            while (true)
            {
                try
                {
                    idFuncionario2 = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Numero de funcionario invalido tente outra vez: ");
                }

            }

            Funcionarios funcionario1 = service.GetFuncionarios(idFuncionario1);
            Funcionarios funcionario2 = service.GetFuncionarios(idFuncionario2);

            try
            {
                service.ChangeFuncionarioCompetencia(funcionario1, funcionario2);
                Console.WriteLine($"Troca de competências entre Funcionarios com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
