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
        public Account Login(Account account)
        {
            return accountRepository.Login(account);
            
            
        }
       
        
    }
}
