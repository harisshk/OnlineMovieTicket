using System.ComponentModel.DataAnnotations;
namespace OnlineMovieTicket.Models
{
    internal class SignupViewModel
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Username Required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Gender Required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Email Required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number Required")]
        [RegularExpression(@"^[6789]\d{9}$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }

    }
}