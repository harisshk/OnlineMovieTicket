using OnlineMovieTicket.Entity;
using System.Linq;
namespace OnlineMovieTicket.Repository
{
    public interface IAccountRepository
    {
        void AddUser(Account account);
        Account CheckUser(Account account);
    }
    public class AccountRepository:IAccountRepository
    {
        public void AddUser(Account account) //Add user to Database
        {
            using (OnlineMovieTicketDBContext onlineMovieTicketDBContext = new OnlineMovieTicketDBContext())
            {
                onlineMovieTicketDBContext.AccountDetails.Add(account);
                onlineMovieTicketDBContext.SaveChanges(); // Update the database
            }
        }
        public Account CheckUser(Account account) //Check existing user.
        {
            using (OnlineMovieTicketDBContext onlineMovieTicketDBContext = new OnlineMovieTicketDBContext())
            {
                var usr = onlineMovieTicketDBContext.AccountDetails.Where(model => model.Email == account.Email && model.Password == account.Password).FirstOrDefault();
                return usr;
            }
        }
        
    }
}
