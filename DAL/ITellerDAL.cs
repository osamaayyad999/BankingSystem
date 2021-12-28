using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DAL
{
    public interface ITellerDAL
    {
        bool Deposit(long customerIdentity, double amount);
        bool Withdraw(long customerIdentity, double amount);
        bool ValidAmount(long customerId, double amount);
    }
}
