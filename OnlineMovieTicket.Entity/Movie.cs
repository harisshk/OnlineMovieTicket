using System;
using System.ComponentModel.DataAnnotations;
namespace OnlineMovieTicket.Entity
{
    public class Movie
    {
        
        public string MovieName { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:HH:MM}")]
        public DateTime ShowTimeMorning { get; set; }


        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:MM}")]
        public DateTime ShowTimeAfternoon { get; set; }


        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:MM}")]
        public DateTime ShowTimeEvening { get; set; }
        [Key]
        public int MovieId { get; set; }
        public double Price { get; set; }
        public string Duration { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}