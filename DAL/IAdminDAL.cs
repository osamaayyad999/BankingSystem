using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace DAL
{
    public interface IAdminDAL
    {
        public Guid AddCustomer(Customer customer, AccountD accountD, AccountBalance accountBalance);
        public bool UpdateCustomer(Customer customer, AccountD accountD, AccountBalance accountBalance);
        public bool DeleteCustomer(long customerIdentity);

    }
}
