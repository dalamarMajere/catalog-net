using Catalog.Dtos;
using Catalog.Entities;

namespace Catalog
{
    public static class Extensions
    {
        public static BookDto AsDto(this Book book)
        {
            return new BookDto() {Id = book.Id, Name = book.Name, Author = book.Author, PageCount = book.PageCount};
        }
    }
}