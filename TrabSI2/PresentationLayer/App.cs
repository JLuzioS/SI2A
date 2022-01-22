﻿using AdoNETLayer;
using BusinessLayer;
using EntityFrameworkLayer;
using ModelLayer;
using System;
using AdoNETLayer.concrete;

namespace PresentationLayer
{
    public class App
    {

        enum DataAccessModel { AdoNET, EntityFramework, Exit }
        enum Operation { CreateFunc, ReadFunc, UpdateFunc, GetALLFunc, GetFreeEqu, CreateInterv, CreateIntervProc, 
            CreateEqu, AddUserToEquipa, RemoveUserFromEquipa, CreateAndAttributeIntervencaoToEquipa,  Exit }

        public static void Main()
        {
            string connectionString = "Data Source=10.62.73.87;Initial Catalog=L51NG3;User Id=L51NG3;Password=L51NG3.passwd88;";

            while (true) {
                var DataAccessModelOption = GetDataAccessModelFromUser();

                Console.WriteLine($"\nChosen option -> {DataAccessModelOption}");

                IDataBase db;
                switch (DataAccessModelOption)
                {
                    case DataAccessModel.AdoNET:
                        using (Context ctx = new Context(connectionString))
                        {
                            db = new AdoNet(ctx);
                        }
                        break;

                    case DataAccessModel.EntityFramework:
                        db = new EntityFramework();
                        break;
                    case DataAccessModel.Exit:
                        return;
                    default:
                        throw new Exception("Invalid Data Access Model");
                }

                OperationsMenu(db);
            }

        }

        private static void OperationsMenu(IDataBase db) {
            Services service = new Services(db);
            FuncionarioPresentation fP = new FuncionarioPresentation(service);
            EquipasPresentation eP = new EquipasPresentation(service);
            IntervencoesPresentation iP = new IntervencoesPresentation(service);

            while (true)
            {
                var OperationOption = GetOperation();

                Console.WriteLine($"Chosen option -> {OperationOption}\n");
                switch (OperationOption)
                {
                    case Operation.CreateFunc:
                        fP.CreateFuncionario();
                        break;
                    case Operation.GetALLFunc:
                        fP.GetAllFuncionarios();
                        break;
                    case Operation.GetFreeEqu:
                        eP.GetFreeEquipa();
                        break;
                    case Operation.CreateIntervProc:
                        iP.CreateIntervencaoProcedure();
                        break;
                    case Operation.CreateInterv:
                        iP.CreateIntervencao();
                        break;
                    case Operation.CreateAndAttributeIntervencaoToEquipa:
                        iP.CreateAndAttributeIntervencaoToEquipa();
                        break;
                    case Operation.CreateEqu:
                        eP.CreateEquipa();
                        break;
                    case Operation.AddUserToEquipa:
                        eP.AddFuncionarioToEquipa();
                        break;
                    case Operation.RemoveUserFromEquipa:
                        eP.DeleteFuncionarioFromEquipa();
                        break;
                    case Operation.Exit:
                        return;
                }
                Console.ReadKey();
            }
        }

        private static DataAccessModel GetDataAccessModelFromUser()
        {
            Console.WriteLine("Select which Data Access Module to use:");
            Console.WriteLine("1. ADO.NET");
            Console.WriteLine("2. Entity Framework");
            Console.WriteLine("3. Exit");

            while (true)
            {
                var option = Console.ReadKey();

                switch (option.KeyChar)
                {
                    case '1':
                        return DataAccessModel.AdoNET;
                    case '2':
                        return DataAccessModel.EntityFramework;
                    case '3':
                        return DataAccessModel.Exit;
                    default:
                        Console.WriteLine("\nNot a valid option.");
                        break;
                }
            }
        }

        private static Operation GetOperation()
        {
            Console.WriteLine("\nSelect which Operation to use:");
            Console.WriteLine("D1. Create Funcionario");
            Console.WriteLine("D2. Delete Funcionario");
            Console.WriteLine("D3. Update Funcionario");
            Console.WriteLine("D4. GetAll Funcionarios");
            Console.WriteLine("E1. Get free Equipa");
            Console.WriteLine("FA. Create Intervencao Procedure");
            Console.WriteLine("FB. Create Intervencao");
            Console.WriteLine("G. Create Equipa");
            Console.WriteLine("G1. Add Funcionario to Equipa");
            Console.WriteLine("G2. Remove Funcionario from Equipa");
            Console.WriteLine("Z. Obter o codigo de uma equipa livre, criar o procedimento e actualiza lo");
            Console.WriteLine("0. Exit");

            while (true)
            {
                var option = Console.ReadLine();

                switch (option)
                {
                    case "D1":
                        return Operation.CreateFunc;
                    case "D2":
                        return Operation.ReadFunc;
                    case "D3":
                        return Operation.UpdateFunc;
                    case "D4":
                        return Operation.GetALLFunc;
                    case "E1":
                        return Operation.GetFreeEqu;
                    case "FA":
                        return Operation.CreateIntervProc;
                    case "FB":
                        return Operation.CreateInterv;
                    case "G":
                        return Operation.CreateEqu;
                    case "G1":
                        return Operation.AddUserToEquipa;
                    case "G2":
                        return Operation.RemoveUserFromEquipa;
                    case "0":
                        return Operation.Exit;
                    case "Z":
                        return Operation.CreateAndAttributeIntervencaoToEquipa;  
                    default:
                        Console.WriteLine("\nNot a valid option.");
                        break;
                }
            }
        }
    }
}
