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

        enum DataAccessModel { AdoNET, EntityFramework }
        enum Operation { CreateFunc, ReadFunc, UpdateFunc, GetALLFunc, GetFreeEqu, Exit }

        public static void Main()
        {
            var DataAccessModelOption = GetDataAccessModelFromUser();

            Console.WriteLine($"\nChosen option -> {DataAccessModelOption}");

            string connectionString = "Data Source=10.62.73.87;Initial Catalog=L51NG3;User Id=L51NG3;Password=L51NG3.passwd88;";


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
                default:
                    throw new Exception("Invalid Data Access Model");
            }

            Services service = new Services(db);
            FuncionarioPresentation fP = new FuncionarioPresentation(service);
            FreeEquipaPresentation feP = new FreeEquipaPresentation(service);

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
                        feP.GetFreeEquipa();
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

            while (true)
            {
                var option = Console.ReadKey();

                switch (option.KeyChar)
                {
                    case '1':
                        return DataAccessModel.AdoNET;
                    case '2':
                        return DataAccessModel.EntityFramework;
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
                    case "0":
                        return Operation.Exit;
                    default:
                        Console.WriteLine("\nNot a valid option.");
                        break;
                }
            }
        }
    }
}
