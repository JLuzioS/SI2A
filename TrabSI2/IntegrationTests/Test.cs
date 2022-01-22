using AdoNETLayer;
using AdoNETLayer.concrete;
using BusinessLayer;
using EntityFrameworkLayer;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Timers;
using System.Transactions;

namespace IntegrationTests
{
    public class Tests
    {
        static ModelLayer.Funcionarios CreateFunc(IDataBase service)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                ModelLayer.Funcionarios func = new ModelLayer.Funcionarios
                {
                    cc = "112233412-123",
                    nif = "992233441",
                    nome = "Teste1",
                    dtNascimento = new DateTime(2021, 12, 31),
                    morada = "Avenida dos testes",
                    codigoPostal = "1234-123",
                    localidade = "Rua do teste",
                    profissao = 1,
                    telefone = "111111111",
                    telemovel = "222222222"
                };
                func.id = service.CreateFuncionario(func);
                ts.Complete();
                return func;
                
            }
        }

        static ModelLayer.Equipas CreateEquipa(IDataBase service)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                ModelLayer.Equipas equipa = new ModelLayer.Equipas
                {
                    id = int.MaxValue,
                    localizacao = "Equipa teste da rua testada",
                    numElementos = 2
                };

                equipa.id = service.CreateEquipa(equipa.localizacao, equipa.numElementos);
                ts.Complete();
                return equipa;
            }
        }


        static void AddFuncToEquipa(IDataBase service, ModelLayer.Equipas equipa, ModelLayer.Funcionarios func)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {

                service.AddFuncionario(equipa, func);
                ts.Complete();
            }
        }

        static void DeleteAll(IDataBase service, ModelLayer.Equipas equipa, ModelLayer.Funcionarios func)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                service.DeleteFuncionario(equipa, func);
                service.RemoveFuncionario(func);
                service.RemoveEquipa(equipa);
                ts.Complete();
            }
        }

        static void AddComp(EntityFramework ef, ModelLayer.Funcionarios func)
        {
            ModelLayer.Competencias c = new ModelLayer.Competencias
            {
                descricao = "cenas"
            };
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                ef.GetCompetencia(c);
                ef.AddCompToFunc(func, c);
                ts.Complete();
            }
        }



        static void Main(string[] args)
        {
            Context ctx = new Context(ConfigurationManager.ConnectionStrings["L51NG3"].ConnectionString);
            var timer = Stopwatch.StartNew();
            AdoNet ado = new AdoNet(ctx);
            EntityFramework ef = new EntityFramework();

            Services serviceEF = new Services(ef);
            Services serviceADO = new Services(ado);
            long adoTime, EFTime;

            ModelLayer.Intervencoes intervencao = new ModelLayer.Intervencoes
            {
                competencias = 1,
                activo = 1,
                vlMonetario = 1,
                dtInicio = DateTime.Now,
                perMeses = 1
            };

            

            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                ModelLayer.Funcionarios func = CreateFunc(ado);
                ModelLayer.Equipas equipa = CreateEquipa(ado);
                AddComp(ef, func);
                AddFuncToEquipa(ado, equipa, func);

                timer.Start();
                serviceADO.CreateAndAttributeIntervencaoToEquipa(intervencao);
                timer.Stop();
                adoTime = timer.ElapsedMilliseconds;
            }

            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {

            }

            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                timer.Start();
                serviceEF.CreateAndAttributeIntervencaoToEquipa(intervencao);
                timer.Stop();
                EFTime = timer.ElapsedMilliseconds;
            }

            

            Console.WriteLine($"ADO.NET time was = {adoTime}");
            Console.WriteLine($"Entity Framework time was = {EFTime}");

            Console.ReadKey();
        }
    }
}
