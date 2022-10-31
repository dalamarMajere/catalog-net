using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record UpdateBookDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        public string Author { get; init; }
        [Required]
        [Range(1, 2000)]
        public int PageCount { get; init; }
    }
}