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
        static ModelLayer.Funcionarios CreateFunc1(IDataBase service)
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

        static ModelLayer.Funcionarios CreateFunc2(IDataBase service)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                ModelLayer.Funcionarios func = new ModelLayer.Funcionarios
                {
                    cc = "112233412-132",
                    nif = "992233432",
                    nome = "Teste13",
                    dtNascimento = new DateTime(2021, 12, 31),
                    morada = "Avenida dos teste3",
                    codigoPostal = "1234-121",
                    localidade = "Rua do tes3e",
                    profissao = 1,
                    telefone = "111111121",
                    telemovel = "222222223"
                };
                func.id = service.CreateFuncionario(func);
                ts.Complete();
                return func;

            }
        }

        static ModelLayer.Equipas CreateEquipa1(IDataBase service)
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

        static ModelLayer.Equipas CreateEquipa2(IDataBase service)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                ModelLayer.Equipas equipa = new ModelLayer.Equipas
                {
                    id = int.MaxValue - 1,
                    localizacao = "Equipa teste da rua testada2",
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

        static void AddComp(EntityFramework ef, ModelLayer.Funcionarios func, ModelLayer.Competencias c)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                ef.GetCompetencia(c);
                ef.AddCompToFunc(func, c);

            }
        }

        

        static void Main(string[] args)
        {
            Context ctx = new Context(ConfigurationManager.ConnectionStrings["L51NG3"].ConnectionString);

            AdoNet ado = new AdoNet(ctx);
            EntityFramework ef = new EntityFramework();
            
            long adoTime, EFTime;

            for (int i = 0; i < 5; i++)
            {
                ModelLayer.Intervencoes intervencao = new ModelLayer.Intervencoes
                {
                    competencias = 1,
                    activo = 1,
                    vlMonetario = 1,
                    dtInicio = DateTime.Now,
                    perMeses = 1
                };
                ModelLayer.Competencias c1 = new ModelLayer.Competencias
                {
                    descricao = "cenas1"
                };
                ModelLayer.Competencias c2 = new ModelLayer.Competencias
                {
                    descricao = "cenas2"
                };

                ModelLayer.Funcionarios func;
                ModelLayer.Equipas equipa;
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    func = CreateFunc1(ado);
                    equipa = CreateEquipa1(ado);
                    ts.Complete();
                }

                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    AddComp(ef, func, c1);
                }

                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    AddFuncToEquipa(ado, equipa, func);
                }

                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    DeleteAll(ado, equipa, func);
                }

                adoTime = adoTester(ctx, intervencao, ef, func, equipa);


                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    func = CreateFunc2(ado);
                    equipa = CreateEquipa2(ado);
                    ts.Complete();
                }

                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    AddComp(ef, func, c2);
                }

                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    AddFuncToEquipa(ado, equipa, func);
                }

                EFTime = efTester(ctx, intervencao, ef, func, equipa);

                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    DeleteAll(ado, equipa, func);
                }
                Console.WriteLine($"{i} iterations");
                Console.WriteLine($"ADO.NET time was = {adoTime}");
                Console.WriteLine($"Entity Framework time was = {EFTime}");
            }

            Console.ReadKey();
        }

        private static long adoTester(Context ctx, ModelLayer.Intervencoes intervencao, EntityFramework ef, ModelLayer.Funcionarios func, ModelLayer.Equipas equipa)
        {
            AdoNet ado = new AdoNet(ctx);
            Services serviceADO = new Services(ado);
            
            var timer = Stopwatch.StartNew();
            long res = 0;

            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                timer.Start();
                serviceADO.CreateAndAttributeIntervencaoToEquipa(intervencao);
                timer.Stop();
                res = timer.ElapsedMilliseconds;
            }

            return res;
        }

        private static long efTester(Context ctx, ModelLayer.Intervencoes intervencao, EntityFramework ef, ModelLayer.Funcionarios func, ModelLayer.Equipas equipa)
        {
            AdoNet ado = new AdoNet(ctx);
            Services serviceEF = new Services(ef);
            var timer = Stopwatch.StartNew();
            long res = 0;

            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                timer.Start();
                serviceEF.CreateAndAttributeIntervencaoToEquipa(intervencao);
                timer.Stop();
                res = timer.ElapsedMilliseconds;
            }

            return res;
        }
    }
}
