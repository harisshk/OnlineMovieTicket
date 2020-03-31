using System.ComponentModel.DataAnnotations;
namespace OnlineMovieTicket.Models
{
    internal class LoginViewModel
    {
        [Required]      
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        
    }
}