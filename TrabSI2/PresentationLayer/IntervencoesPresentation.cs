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

            Intervencoes intervencoes = new Intervencoes();

            GetAllCompetencias();
            intervencoes.competencias = GetCompetencia();
            intervencoes.estado = "Por atribuir";
            GetAllActivos();
            intervencoes.activo = GetActivo();
            intervencoes.vlMonetario = GetValorMonetario();
            intervencoes.dtInicio = GetDataInicio();
            intervencoes.dtFim = null;
            intervencoes.perMeses = GetPerMeses();

            if (service.CreateIntervencao(intervencoes))
            {
                Console.WriteLine("Intervencao criado com sucesso!");
            }
            else
            {
                Console.WriteLine("Algo correu mal! Nao sei");
            }
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
            Console.WriteLine("Competência para associar a intervencão:");
            var option = Console.ReadLine();
            // TODO DATA Validation
            return Int32.Parse(option);
        }

        private void GetAllActivos()
        {
            Console.WriteLine("Lista de Activos: ");
            foreach (var activo in service.GetAllActivos())
            {
                Console.WriteLine(activo.id + " - " + activo.nome);
            }
        }

        private int GetActivo()
        {
            Console.WriteLine("Activo para associar a intervencão:");
            var option = Console.ReadLine();
            // TODO DATA Validation
            return Int32.Parse(option);
        }

        private decimal GetValorMonetario()
        {
            Console.WriteLine("Valor monetario:");
            var option = Console.ReadLine();
            // TODO DATA Validation
            return decimal.Parse(option);
        }

        private DateTime GetDataInicio()
        {
            Console.WriteLine("Data de inicio <YYYY-MM-DD>:");
            var option = Console.ReadLine();
            // TODO DATA Validation
            return DateTime.Parse(option);
        }

        private int GetPerMeses()
        {
            Console.WriteLine("Periodo da intervenção:");
            var option = Console.ReadLine();
            // TODO DATA Validation
            return int.Parse(option);
        }
    }
}
