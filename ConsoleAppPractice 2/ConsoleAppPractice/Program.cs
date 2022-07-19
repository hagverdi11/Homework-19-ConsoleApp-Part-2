using Domain.Models;
using LibraryApp.Controllers;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;

namespace ConsoleAppPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryServices libraryServices = new LibraryServices();
            LibraryController libraryController = new LibraryController();

            Helper.WriteConsole(ConsoleColor.Blue, "Select one option");

            GetMenues();

            while (true)
            {
                SelectOption: string selectOption = Console.ReadLine();

                int selectTrueOption;

                bool isSelectOption = int.TryParse(selectOption, out selectTrueOption);

                if (isSelectOption)
                {
                    switch (selectTrueOption)
                    {
                        case (int) Menues.CreateLibrary:

                            libraryController.Create();
                            











                            break;

                        case (int) Menues.GetLibraryById:

                            libraryController.GetById();

                            break;

                        case (int) Menues.UpdateLibrary:
                            libraryController.Update();
                            break;

                        case (int) Menues.DeleteLibrary:
                            libraryController.Delete();
                            break;

                        case (int) Menues.GetAllLibraries:
                            libraryController.GetAll();
                            break;

                        case (int) Menues.SearchLibrary:

                            libraryController.Search();
                           
                            break;

                        default:
                            Console.WriteLine("Select correct option number");
                            break;
                    }



                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Retype your text");
                    goto SelectOption;
                }
            }
        }


        private static void GetMenues()
        {
            Helper.WriteConsole(ConsoleColor.Magenta, "1 - Create library, 2 - Get library by id, 3 - Update library, 4 - Delete library, 5 - Get all libraries, 6 - Search for library by names");

        }



    }
}
