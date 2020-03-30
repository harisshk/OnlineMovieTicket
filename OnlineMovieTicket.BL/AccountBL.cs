using OnlineMovieTicket.Entity; 

using OnlineMovieTicket.Repository;

namespace OnlineMovieTicket.BL
{
    public interface IAccountBL
    {
        void AddUser(Account account);
        Account ChechkUser(Account account);
    }
    public class AccountBL:IAccountBL
    {
        public AccountRepository accountRepository = new AccountRepository();

        public void AddUser(Account account)
        {
            accountRepository.AddUser(account);
        }
        public Account ChechkUser(Account account)
        {
            return accountRepository.ChechkUser(account);
        }
    }
}
