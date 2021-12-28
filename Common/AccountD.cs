using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class AccountD
    {
		[Key]
		public int AccountID { get; set; }
		[ForeignKey("CustomerID")]
		public Guid CustomerID { get; set; }
		public string AccountType { get; set; }
		public bool AccountStatus { get; set; }
		public string AccountCreateTime { get; set; }

	}
}
