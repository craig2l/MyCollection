using MagicCollection.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicCollection.API.Repository
{
    public interface IMagicCollectionRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<Book>> GetBooks();
        Task<IEnumerable<Poster>> GetPosters();
        Task<Book> GetBook(int id);
        Task<Poster> GetPoster(int id);
    }
}
