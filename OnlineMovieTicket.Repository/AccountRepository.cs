using OnlineMovieTicket.Entity;
using System.Linq;
namespace OnlineMovieTicket.Repository
{
    public interface IAccountRepository
    {
        void AddUser(Account account);
        Account ChechkUser(Account account);
    }
    public class AccountRepository:IAccountRepository
    {
        public void AddUser(Account account)
        {
            using (OnlineMovieTicketDBContext onlineMovieTicketDBContext = new OnlineMovieTicketDBContext())
            {
                onlineMovieTicketDBContext.AccountDetail.Add(account);
                onlineMovieTicketDBContext.SaveChanges();
            }
        }
        public Account ChechkUser(Account account)
        {
            using (OnlineMovieTicketDBContext onlineMovieTicketDBContext = new OnlineMovieTicketDBContext())
            {
                var usr = onlineMovieTicketDBContext.AccountDetail.Where(model => model.Email == account.Email && model.Password == account.Password).FirstOrDefault();
                return usr;
            }
        }
        
    }
}
