using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class AccountBalance
    {
        [Key]
        public int AccountBalanceId { get; set; }
        [ForeignKey("AccountID")]
        public int AccountID { get; set; }
        public double AccountAmount { get; set; }
	    public bool AccountAmountStatus { get; set; }

    }
}
