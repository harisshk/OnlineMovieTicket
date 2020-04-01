using OnlineMovieTicket.Entity; 

using OnlineMovieTicket.Repository;

namespace OnlineMovieTicket.BL
{
    public interface IAccountBL //Interface for AccountBL
    {
        void AddUser(Account account);
        Account CheckUser(Account account);
    }
    public class AccountBL:IAccountBL
    {
        public AccountRepository accountRepository = new AccountRepository();

        public void AddUser(Account account) //Add user 
        {
            account.Role = "User";
            accountRepository.AddUser(account);
        }
        public Account CheckUser(Account account) //Check user
        {
            return accountRepository.CheckUser(account);
        }
    }
}
