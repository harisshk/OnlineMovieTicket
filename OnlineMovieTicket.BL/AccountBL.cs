using OnlineMovieTicket.Entity;
using OnlineMovieTicket.Repository;

namespace OnlineMovieTicket.BL
{
    public class AccountBL
    {
        public AccountRepository accountRepository = new AccountRepository();

        public void Signup(Account account)
        {
            accountRepository.Signup(account);
        }
        public bool Login(Account account)
        {
            if (accountRepository.Login(account))
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
