using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interfaces
{
    interface ILibraryServices
    {
        Library Create(Library library);
        Library Update(int id, Library library);
        void Delete(int id);
        Library GetById(int id);
        List<Library> GetAll();
        List<Library> Search(string search);

    }
}
