using OnlineMovieTicket.Entity;
using System.Linq;
namespace OnlineMovieTicket.Repository
{
    public class AccountRepository
    {
        public void Signup(Account account)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                database.AccountDetail.Add(account);
                database.SaveChanges();
            }
        }
        public Account Login(Account account)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                var usr = database.AccountDetail.Where(model => model.Email == account.Email && model.Password == account.Password).FirstOrDefault();
                return usr;
            }
        }
        
    }
}
