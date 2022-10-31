using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record CreateBookDto
    {
        [Required]
        public string Name { get; init; }
        public string Author { get; init; }
        [Range(1, 2000)]
        public int PageCount { get; init; }
    }
}