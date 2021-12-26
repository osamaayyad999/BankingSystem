using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public class AccountD
    {
		
		public Guid AccountDID { get; set; }
		public int CustomerID { get; set; }
		public string AccountType { get; set; }
		public bool AccountStatus { get; set; }
		public DateTime AccountCreateTime { get; set; }
	    public DateTime AccountlastSeenTime { get; set; }
	}
}
