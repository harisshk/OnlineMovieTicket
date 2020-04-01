    
using System.ComponentModel.DataAnnotations;

namespace OnlineMovieTicket.Entity
{
    public class Account
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
     
    }
}