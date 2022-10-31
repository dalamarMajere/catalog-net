using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<BookDto> GetBooks()
        {
            return _repository.GetBooks().Select(book => book.AsDto());
        }

        //GET /item/{id}
        [HttpGet("{id}")]
        public ActionResult<BookDto> GetBook(Guid id)
        {
            var book = _repository.GetBook(id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book.AsDto());
        }

        // POST /books
        [HttpPost]
        public ActionResult<BookDto> AddBook(CreateBookDto createBookDto)
        {
            Book book = new()
            {
                Id = Guid.NewGuid(),
                Name = createBookDto.Name,
                Author = createBookDto.Author,
                PageCount = createBookDto.PageCount
            };

            _repository.CreateBook(book);

            return CreatedAtAction(nameof(GetBook), new {id = book.Id}, book.AsDto());
        }

        // PUT /item
        [HttpPut("{id}")]
        public ActionResult UpdateBook(Guid id, UpdateBookDto updateBookDto)
        {
            var existingBook = _repository.GetBook(id);

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
            
            _repository.UpdateBook(updatedBook);

            return NoContent();
        }

        // DELETE /item/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingBook = _repository.GetBook(id);

            if (existingBook is null)
            {
                return NotFound();
            }
            
            _repository.DeleteBook(existingBook);

            return NoContent();
        }
    }
}