using Domain.Models;
using Repository.Repostories;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class LibraryServices : ILibraryServices
    {

        private LibraryRepository _libraryRepository;
        private int _count;
        public LibraryServices()
        {
            _libraryRepository = new LibraryRepository();
        }
        public Library Create(Library library)
        {
            library.Id = _count;
            _libraryRepository.Create(library);
            _count++;
            return library;

        }

        public void Delete(int id)
        {
            Library library = GetById(id);
            _libraryRepository.Delete(library);
        }

        public List<Library> GetAll()
        {
            return _libraryRepository.GetAll();
        }

        public List<Library> Search(string search)
        {
            return _libraryRepository.GetAll(m => m.Name.Trim().ToLower().StartsWith(search.ToLower().Trim()));
        }

        public Library GetById(int id)
        {
            var library = _libraryRepository.Get(m => m.Id == id);
            if (library is null) return null;
            return library;
        }

        public Library Update(int id, Library library)
        {
            Library dblibrary = GetById(id);
            if (dblibrary is null) return null;
            dblibrary.Id = library.Id;
            _libraryRepository.Update(library);
            return library;
        }
    }
}
