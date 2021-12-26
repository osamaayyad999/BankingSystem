using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public class Customer
    {
		public int AccountID { get; set; }
		public int CustomerID { get; set; }
		public string CustomerFirstName { get; set; }
		public string CustomerLastName { get; set; }
		public string CustomerGender { get; set; }
		public string CustomerEmail { get; set; }
		public int CustomerPhone { get; set; }
		public int CustomerIdentity { get; set; }
		public bool CustomerStatus { get; set; }

	}
}
