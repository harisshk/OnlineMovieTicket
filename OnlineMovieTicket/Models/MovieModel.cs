using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace OnlineMovieTicket.Models
{
    public class MovieModel
    {
       [Key]
        public string MovieName { get; set; }

        public string ShowTime { get; set; }

        public int MovieId { get; set; }

        public double Price { get; set; }
    }
}