using System.ComponentModel.DataAnnotations;

namespace OnlineMovieTicket.Models
{
    public class MovieModel
    {
       [Required(ErrorMessage ="Movie name is required")]
        public string MovieName { get; set; }
        [Required(ErrorMessage = "Show time for morning is required")]
        public string ShowTimeMorning { get; set; }
        [Required(ErrorMessage = "Show time for afternoon is required")]
        public string ShowTimeAfternoon { get; set; }
        [Required(ErrorMessage = "Show time for evening is required")]
        public string ShowTimeEvening { get; set; }
        [Key]
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Duration for movie is required")]
        public string Duration { get; set; }
    }
}