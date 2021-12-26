using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public interface IAdminDAL
    {
        int CreateAccount(Account account); // to create a new account
        int UpdateAccount(Account account); // to update account data when coustmer make a deposit or withdraw money from his account
        int DeleteAccount(Account account); // to make account status is closed
        Account GetAccount(uint id);
        void SavaData();
        void ReadData();


    }
}
