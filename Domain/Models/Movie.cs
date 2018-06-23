using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public partial class Movie
    {
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string PosterUrl { get; set; }
        public string VideoUrl { get; set; }
        public string VideoPosterUrl { get; set; }
        public string Summary { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
    }
}
