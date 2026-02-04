using System.ComponentModel.DataAnnotations;

namespace MovieStoreWebsite.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty; // Initialize with empty string

        [Required]
        public string Genre { get; set; } = string.Empty; // Initialize with empty string

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

     
        public string? Director { get; set; }

        public string? Description { get; set; }

        [Display(Name = "Poster Image URL")]
        public string? ImageUrl { get; set; } // We use a URL to link to the movie poster

        public double Rating { get; set; }
    }
}