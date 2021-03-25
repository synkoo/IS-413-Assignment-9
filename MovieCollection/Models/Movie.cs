using System;
using System.ComponentModel.DataAnnotations;

namespace MovieCollection.Models
{
    public class Movie
    {
        public Movie()
        {
        }

        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        //Edited field is boolean

#nullable enable
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }

        //Notes field is limited to 25 characters

        [MaxLength(25, ErrorMessage = "Note cannot exceed 25 characters.")]
        public string? Notes { get; set; }
#nullable disable

    }
}
