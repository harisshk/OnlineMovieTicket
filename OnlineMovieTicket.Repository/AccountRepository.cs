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
        public void AddUser(Account account)
        {
            using (OnlineMovieTicketDBContext onlineMovieTicketDBContext = new OnlineMovieTicketDBContext())
            {
                onlineMovieTicketDBContext.AccountDetails.Add(account);
                onlineMovieTicketDBContext.SaveChanges();
            }
        }
        public Account CheckUser(Account account)
        {
            using (OnlineMovieTicketDBContext onlineMovieTicketDBContext = new OnlineMovieTicketDBContext())
            {
                var usr = onlineMovieTicketDBContext.AccountDetails.Where(model => model.Email == account.Email && model.Password == account.Password).FirstOrDefault();
                return usr;
            }
        }
        
    }
}
