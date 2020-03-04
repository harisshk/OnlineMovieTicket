namespace OnlineMovieTicket.Entity
{
    public class Account
    {
       
        public string Name { get; set; }

        public string Gender { get; set; }

        
        public string Email { get; set; }

        
        public string DateOfBirth { get; set; }

        public string Phone { get; set; }

       
        public string Password { get; set; }


        public Account(string name, string gender, string email, string dob, string phone, string password)
        {
            this.Name = name;
            this.Gender = gender;
            this.DateOfBirth = dob;
            this.Email = email;
            this.Password = password;
            this.Phone = phone;
        }
        public Account()
        {

        }

    }
}