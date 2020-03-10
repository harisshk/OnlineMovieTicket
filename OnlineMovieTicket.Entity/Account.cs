﻿
using System.ComponentModel.DataAnnotations;

namespace OnlineMovieTicket.Entity
{
    public class Account
    {
        [Key]
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        
        public string Email { get; set; }


        public string Phone { get; set; }

       
        public string Password { get; set; }


       
        public Account()
        {

        }

    }
}