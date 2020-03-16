using System.ComponentModel.DataAnnotations;
namespace OnlineMovieTicket.Entity
{
    public class Movie
    {
        
        public string MovieName { get; set; }
        public string ShowTimeMorning { get; set; }
        public string ShowTimeAfternoon { get; set; }
        public string ShowTimeEvening { get; set; }
        [Key]
        public int MovieId { get; set; }
        public double Price { get; set; }
        public string Duration { get; set; }
        public Category CategoryId { get; set; }
    }
}