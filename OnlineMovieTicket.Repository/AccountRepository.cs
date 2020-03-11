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
        public bool Login(Account account)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                var usr = database.AccountDetail.SingleOrDefault(model => model.Name == account.Name && model.Password == account.Password);
                if (usr != null)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
        }
    }
}
