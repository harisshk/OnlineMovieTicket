using OnlineMovieTicket.Entity; 

using OnlineMovieTicket.Repository;

namespace OnlineMovieTicket.BL
{
    public interface IAccountBL
    {
        void AddUser(Account account);
        Account CheckUser(Account account);
    }
    public class AccountBL:IAccountBL
    {
        public AccountRepository accountRepository = new AccountRepository();

        public void AddUser(Account account)
        {
            account.Role = "User";
            accountRepository.AddUser(account);
        }
        public Account CheckUser(Account account)
        {
            return accountRepository.CheckUser(account);
        }
    }
}
