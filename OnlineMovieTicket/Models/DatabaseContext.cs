    using System.Data.Entity;
namespace OnlineMovieTicket.Models
{

    public class DatabaseContext : DbContext
    {
        

        public DbSet<SignupViewModel> signupViewModel { get; set; }
    }
}