using BusinessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    class CompetenciasPresentation
    {
        private Services service;

        public CompetenciasPresentation(Services service)
        {
            this.service = service;
        }

        private void GetAllCompetencias()
        {
            Console.WriteLine("Lista de Competências: ");
            foreach (var comp in service.GetAllCompetencias())
            {
                Console.WriteLine(comp.id + " - " + comp.descricao);
            }
        }

        private int GetCompetencia()
        {
            Console.WriteLine("Escolha uma competência para saber qual a equipa disponível: ");
            var option = Console.ReadLine();
            // TODO DATA Validation
            return Int32.Parse(option);
        }

        public void GetFreeEquipa()
        {
            
            GetAllCompetencias();

            int competenciaId = GetCompetencia();
            Console.WriteLine("A equipa " + service.GetFreeEquipa(competenciaId) + " contendo funcionários com a competência " + competenciaId + " está disponível.");
        }
        public void AddFuncionarioToEquipa()
        {
            Console.WriteLine("Insira o id da equipa pretendida: ");
            int idEquipa;
            while (true)
            {
                try
                {
                    idEquipa = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Numero de equipa invalido tente outra vez: ");
                }

            }

            Console.WriteLine("Insira o id do funcionario pretendido: ");
            int idFuncionario;
            while (true)
            {
                try
                {
                    idFuncionario = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Numero de funcionario invalido tente outra vez: ");
                }

            }

            Equipas equipa = service.GetEquipa(idEquipa);
            Funcionarios funcionario = service.GetFuncionarios(idFuncionario);

            try
            {
                service.AddFuncionarioToEquipa(equipa, funcionario);
                Console.WriteLine($"Funcionario adicionado com sucesso");
            }catch (Exception)
            {
                Console.WriteLine("Houve um erro a adicionar o funcionario à equipa");
            }

        }

        public void DeleteFuncionarioFromEquipa()
        {
            Console.WriteLine("Insira o id da equipa pretendida: ");
            int idEquipa;
            while (true)
            {
                try
                {
                    idEquipa = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Numero de equipa invalido tente outra vez: ");
                }

            }

            Console.WriteLine("Insira o id do funcionario pretendido: ");
            int idFuncionario;
            while (true)
            {
                try
                {
                    idFuncionario = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Numero de funcionario invalido tente outra vez: ");
                }

            }

            Equipas equipa = service.GetEquipa(idEquipa);
            Funcionarios funcionario = service.GetFuncionarios(idFuncionario);

            try
            {
                service.DeleteFuncionarioFromEquipa(equipa, funcionario);
                Console.WriteLine($"Funcionario removido com sucesso");
            }
            catch (Exception)
            {
                Console.WriteLine("Houve um erro a adicionar o funcionario à equipa");
            }
        }
    }
}
