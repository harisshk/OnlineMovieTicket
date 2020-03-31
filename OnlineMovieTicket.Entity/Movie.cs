using System;
using System.ComponentModel.DataAnnotations;
namespace OnlineMovieTicket.Entity
{
    public class Movie
    {
        [Required(ErrorMessage = "Movie name is required")]
        [MaxLength(20)]
        public string MovieName { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:HH:MM}")]
        public DateTime ShowTimeMorning { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:MM}")]
        public DateTime ShowTimeAfternoon { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:MM}")]
        public DateTime ShowTimeEvening { get; set; }
        [Key]
        public int MovieId { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Duration { get; set; }
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}