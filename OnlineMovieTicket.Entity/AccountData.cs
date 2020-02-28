using System.ComponentModel.DataAnnotations;
namespace OnlineMovieTicket.Entity
{
    public class AccountData
    {
        
        [Required(ErrorMessage ="Name Required")]
        
        public string Name { get; set; }

        [Required(ErrorMessage = "Gender Required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of Birth Required")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "Phone number Required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public AccountData(string name, string gender, string email, string dob, string phone, string password)
        {
            this.Name = name;
            this.Gender = gender;
            this.DateOfBirth = dob;
            this.Email = email;
            this.Password = password;
            this.Phone = phone;
        }
        public AccountData()
        {

        }

    }
}