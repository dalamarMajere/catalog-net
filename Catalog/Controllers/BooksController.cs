using System;
using System.Collections.Generic;
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
        private readonly InMemBookRepository _repository;

        public BooksController()
        {
            _repository = new ();
        }

        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return _repository.GetBooks();
        }

        //GET /item/{id}
        [HttpGet("{id}")]
        public Book GetBooks(Guid id)
        {
            return _repository.GetBook(id);
        }
    }
}