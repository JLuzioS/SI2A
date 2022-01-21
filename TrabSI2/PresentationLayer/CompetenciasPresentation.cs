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
    }
}
