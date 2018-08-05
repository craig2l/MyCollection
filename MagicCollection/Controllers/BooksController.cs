using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagicCollection.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MagicCollection.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private MagicCollectionContext _db { get; }

        // using dependency injection here
        public BooksController(MagicCollectionContext context)
        {
            _db = context;
        }

        
        [HttpGet("GetBook/{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var singleBook = await _db.Books.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(singleBook);
        }
        
        // GET: api/values        
        [HttpGet]
        //public IEnumerable<Book> Get()
        public async Task<IActionResult> Get()
        {
            var list = await _db.Books.ToListAsync(); //as IEnumerable<Books>;
            return Ok(list);
        }

        [HttpGet("First/")]
        public Book First()
        {
            return _db.Books.FirstOrDefault();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
