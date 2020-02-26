using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMovieTicket.Entity
{
    public class AccountData
    {

        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Phone { get; set; }
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

    }
}