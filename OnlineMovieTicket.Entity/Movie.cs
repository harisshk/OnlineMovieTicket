using System.ComponentModel.DataAnnotations;
namespace OnlineMovieTicket.Entity
{
    public class Movie
    {
        [Required  (AllowEmptyStrings =false, ErrorMessage ="Enter the movie name ")]
        [Display(Name="Movie Name")]
        public string MovieName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the show time ")]
        public string ShowTime { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the movie id ")]
        public int MovieId { get; set; }

        [Required(AllowEmptyStrings  = false, ErrorMessage = "Enter the price ")]
        public double Price { get; set; }


    }
}