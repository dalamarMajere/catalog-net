using System;

namespace Catalog.Dtos
{
    public record BookDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Author { get; init; }       
        public int PageCount { get; init; }
    }
}