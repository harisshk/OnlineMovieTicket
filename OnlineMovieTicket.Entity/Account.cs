
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


        public Account(string name, string gender, string email, string dob, string phone, string password)
        {
            this.Name = name;
            this.Gender = gender;
            this.Email = email;
            this.Password = password;
            this.Phone = phone;
        }
        public Account()
        {

        }

    }
}