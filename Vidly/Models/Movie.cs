
using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please enter a movie name")]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number in stock")]
        public int? NumberInStock { get; set; }

        public int? NumberAvailable { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
        
        public Genre Genre { get; set; }
    }
}