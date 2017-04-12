
using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Required]
        [Display(Name = "Number in stock")]
        public int NumberInStock { get; set; }
        
        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
        
        public Genre Genre { get; set; }
    }
}