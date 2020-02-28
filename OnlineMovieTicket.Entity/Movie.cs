using System.ComponentModel.DataAnnotations;
namespace OnlineMovieTicket.Entity
{
    public class Movie
    {
        [Display (Name ="Movie Name")]
        [Required  (AllowEmptyStrings =false, ErrorMessage ="Enter the movie name ")]
        public string MovieName { get; set; }

        [Display(Name = "Show Time")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the show time ")]
        public string ShowTime { get; set; }

        [Display(Name = "Movie Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the movie id ")]
        public int MovieId { get; set; }

        [Display(Name = "Price")]
        [Required(AllowEmptyStrings  = false, ErrorMessage = "Enter the price ")]
        public double Price { get; set; }

    }
}