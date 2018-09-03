using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagicCollection.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using MagicCollection.API.Repository;
using AutoMapper;
using MagicCollection.API.Dto;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MagicCollection.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IMapper _mapper;
        //private AutoMapper _autoMapper;
        //private MagicCollectionContext _db { get; }
        public IMagicCollectionRepository _repo { get; }

        // using dependency injection here
        public BooksController(IMagicCollectionRepository repo, IMapper mapper)
        {           
            _repo = repo;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("getbook/{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var singleBook = await _repo.GetBook(id);

            var bookLite = _mapper.Map<BookLite>(singleBook);
            return Ok(bookLite);
        }
               
        [AllowAnonymous]
        [HttpGet("getbooks/")]        
        public async Task<IActionResult> GetBooks()
        {
            var books = await _repo.GetBooks(); //as IEnumerable<Books>;
            return Ok(books);
        }

        //[HttpGet("First/")]
        //public Book First()
        //{
        //    return _repo.Books.FirstOrDefault();
        //}

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
