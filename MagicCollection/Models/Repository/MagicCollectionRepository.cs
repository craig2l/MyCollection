using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicCollection.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicCollection.API.Repository
{
    public class MagicCollectionRepository : IMagicCollectionRepository
    {
        private readonly MagicCollectionContext _context;

        public MagicCollectionRepository(MagicCollectionContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Book> GetBook(int id)
        {
            //var book = await _context.Books.Include(p => p.Photos).FirstOrDefaultAsync(b => b.Id == id);
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            return book;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            //var users = await _context.Books.Include(p => p.Photos).ToListAsync<Book>();
            var users = await _context.Books.ToListAsync<Book>();
            return users;
        }

        public async Task<Poster> GetPoster(int id)
        {
            var poster = await _context.Posters.Include(p => p.Photos).FirstOrDefaultAsync(p => p.Id == id);
            return poster;
        }

        public async Task<IEnumerable<Poster>> GetPosters()
        {
            var posters = await _context.Posters.Include(p => p.Photos).ToListAsync<Poster>();
            return posters;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
