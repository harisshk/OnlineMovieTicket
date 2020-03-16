using System.ComponentModel.DataAnnotations;
namespace OnlineMovieTicket.Entity
{
    public class Movie
    {
        [Required]
        [Display(Name="Movie Name")]
        public string MovieName { get; set; }

        [Required]
        public string ShowTime { get; set; }

        [Required]
        public int MovieId { get; set; }

        [Required]
        public double Price { get; set; }


    }
}