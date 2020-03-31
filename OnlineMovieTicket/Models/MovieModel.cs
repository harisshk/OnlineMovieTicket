using System.ComponentModel.DataAnnotations;
using System;

namespace OnlineMovieTicket.Models
{
    internal class MovieModel
    {
       [Required(ErrorMessage ="Movie name is required")]
       [MaxLength(20)]
        public string MovieName { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:MM}")]
        [Required(ErrorMessage = "Show time for morning is required")]
        public DateTime ShowTimeMorning { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:MM}")]
        [Required(ErrorMessage = "Show time for afternoon is required")]
        public DateTime ShowTimeAfternoon { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:MM}")]
        [Required(ErrorMessage = "Show time for evening is required")]
        public DateTime ShowTimeEvening { get; set; }

        [Key]
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Duration for movie is required")]
        public string Duration { get; set; }
        public int CategoryId { get; set; }
        internal CategoryModel CategoryModel { get; set; }

    }
}