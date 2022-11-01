using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    // GET /books

    [ApiController]
    [Route("books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            var books = (await _repository.GetBooksAsync()).
                                        Select(book => book.AsDto());
            return books;
        }

        //GET /item/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookAsync(Guid id)
        {
            var book = await _repository.GetBookAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book.AsDto());
        }

        // POST /books
        [HttpPost]
        public async Task<ActionResult<BookDto>> AddBookAsync(CreateBookDto createBookDto)
        {
            Book book = new()
            {
                Id = Guid.NewGuid(),
                Name = createBookDto.Name,
                Author = createBookDto.Author,
                PageCount = createBookDto.PageCount
            };

            await _repository.CreateBookAsync(book);

            return CreatedAtAction(nameof(GetBookAsync), new {id = book.Id}, book.AsDto());
        }

        // PUT /item
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBookAsync(Guid id, UpdateBookDto updateBookDto)
        {
            var existingBook = await _repository.GetBookAsync(id);

            if (existingBook is null)
            {
                return NotFound();
            }

            Book updatedBook = existingBook with
            {
                Name = updateBookDto.Name,
                Author = updateBookDto.Author,
                PageCount = updateBookDto.PageCount
            };
            
            await _repository.UpdateBookAsync(updatedBook);

            return NoContent();
        }

        // DELETE /item/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            var existingBook = await _repository.GetBookAsync(id);

            if (existingBook is null)
            {
                return NotFound();
            }
            
            await _repository.DeleteBookAsync(existingBook);

            return NoContent();
        }
    }
}