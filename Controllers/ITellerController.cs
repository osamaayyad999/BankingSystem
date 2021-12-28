using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL;

namespace Controllers
{
    public interface ITellerController
    {
        public void Deposit();
        public void Withdraw();
    }
}
