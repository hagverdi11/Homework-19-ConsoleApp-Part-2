using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Controllers
{
    class LibraryController
    {

        LibraryServices libraryServices = new LibraryServices();


        public void Create()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add library name :");
            string libraryName = Console.ReadLine();

            Helper.WriteConsole(ConsoleColor.Blue, "Add library seat count : ");

            SeatCount: string librarySeatCount = Console.ReadLine();

            int seatCount;

            bool isSeatCount = int.TryParse(librarySeatCount, out seatCount);

            if (isSeatCount)
            {
                Library library = new Library
                {
                    Name = libraryName,
                    SeatCount = seatCount

                };
                var result = libraryServices.Create(library);
                Helper.WriteConsole(ConsoleColor.Green, $"Library id : {result.Id}, name: {result.Name}, Seat Count: {result.SeatCount}");


            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct seat count : ");
                goto SeatCount;
            }
        }

        public void GetById()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add library id :");
            LibraryId: string libraryId = Console.ReadLine();
            int id;

            bool isLibraryId = int.TryParse(libraryId, out id);

            if (isLibraryId)
            {
                Library library = libraryServices.GetById(id);
                if (library != null)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Library id : {library.Id}, name: {library.Name}, Seat Count: {library.SeatCount}");
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Library not found");
                    goto LibraryId;
                }

            }
            else
            {
                Console.WriteLine("Select correct id type");
                goto LibraryId;
            }
        }

        public void GetAll()
        {
            List<Library> libraries = libraryServices.GetAll();
            foreach (var item in libraries)
                Helper.WriteConsole(ConsoleColor.Green, $"Library id : {item.Id}, name: {item.Name}, Seat Count: {item.SeatCount}");
        }

        public void Search()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add library search text :");
            SearchText: string search = Console.ReadLine();
            List<Library> resultLibraries = libraryServices.Search(search);
            if (resultLibraries != null)
            {
                foreach (var item in resultLibraries)
                    Helper.WriteConsole(ConsoleColor.Green, $"Library id : {item.Id}, name: {item.Name}, Seat Count: {item.SeatCount}");

            }
            else
            {
                Console.WriteLine("Library not found.");
                goto SearchText;
            }
        }

        public void Delete()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add library id :");
            LibraryId: string libraryId = Console.ReadLine();
            int id;

            bool isLibraryId = int.TryParse(libraryId, out id);

            if (isLibraryId)
            {
                libraryServices.Delete(id);
            
            }
            else
            {
                Console.WriteLine("Select correct id type");
                goto LibraryId;
            }

        }

        public void Update()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add library name :");
            LibraryId: string updateLibraryId = Console.ReadLine();
            int libraryId;
            bool isLibraryId = int.TryParse(updateLibraryId, out libraryId);
            if (isLibraryId)
            {
                Helper.WriteConsole(ConsoleColor.Blue, "Add library new name :");

                string libraryNewName = Console.ReadLine();

                Helper.WriteConsole(ConsoleColor.Blue, "Add library new seat count :");

                SeatCount: string libraryNewSeatCount = Console.ReadLine();

                int seatCount;

                bool isSeatCount = int.TryParse(libraryNewSeatCount, out seatCount);

                if (isSeatCount)
                {
                    Library library = new Library()
                    {
                        Name = libraryNewName,
                        SeatCount = seatCount
                        
                    };
                    var resultLibrary = libraryServices.Update(libraryId, library);
                    if (resultLibrary == null)
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Library not found, please try again : ");
                        goto LibraryId;

                    }
                    else
                    {

                        Helper.WriteConsole(ConsoleColor.Green, $"Library id : {resultLibrary.Id}, name: {resultLibrary.Name}, Seat Count: {resultLibrary.SeatCount}");
                    }

                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Add correct seat count : ");
                    goto SeatCount;

                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct library id : ");
                goto LibraryId;

            }

        }
    }
}
