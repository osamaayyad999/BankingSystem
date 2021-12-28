using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Customer
    {
		[Key]
		public Guid CustomerID { get; set; }
		public long CustomerIdentity { get; set; }
		public string CustomerName { get; set; }
		public string CustomerGender { get; set; }
		public string CustomerEmail { get; set; }
		public long CustomerPhone { get; set; }
		public bool CustomerStatus { get; set; }

	}
}
