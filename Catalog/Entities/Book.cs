using System;
using System.Security.Cryptography;

namespace Catalog.Entities
{
    public record Book
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Author { get; init; }       
        public int PageCount { get; init; }
    }
}