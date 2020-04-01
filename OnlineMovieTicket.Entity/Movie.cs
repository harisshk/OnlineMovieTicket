using System;
using System.ComponentModel.DataAnnotations;
namespace OnlineMovieTicket.Entity
{
    public class Movie
    {
        [Required]
        [MaxLength(20)]
        public string MovieName { get; set; }
        [Required]
        public DateTime ShowTimeMorning { get; set; }
        [Required]
        public DateTime ShowTimeAfternoon { get; set; }
        [Required]
        public DateTime ShowTimeEvening { get; set; }
        [Key]
        public int MovieId { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [MaxLength(10)]
        public string Duration { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}