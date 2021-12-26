using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public interface IAdminController
    {
        public void Login();
        public void Signup();
        public void DepositMoney(Account account);
        public void WithdrawMoney(Account account);
        void DisplayDetails(Account account);
        void WriteAuditFile(string str);
    }
}
