using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public class AccountBalance
    {
        public int AccountBalanceId { get; set; }
        public int AccountID { get; set; }
        public double AccountAmount { get; set; }
	    public bool AccountAmountStatus { get; set; }

    }
}
