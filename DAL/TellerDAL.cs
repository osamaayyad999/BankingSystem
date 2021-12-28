using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DAL
{
    public class TellerDAL : ITellerDAL
    {
        private static TellerDAL TellerDALInstance = null;
        private static object lockObj = new object();
        private TellerDAL() { }

        // this method is used to return one instance of class
        public static TellerDAL GetInstance()
        {
            if (TellerDALInstance == null)
            {
                lock (lockObj)
                {
                    if (TellerDALInstance == null)
                    {
                        TellerDALInstance = new TellerDAL();
                    }
                }
            }
            return TellerDALInstance;
        }

        DataDbContext _dbContext = new DataDbContext();

        #region [Deposit Method]
        /// <summary>
        /// This method is to deposit money in specific account
        /// </summary>
        /// <param name="customerIdentity"></param>
        /// <param name="amount"></param>
        /// <returns>
        /// true if the amount is deposit success
        /// false if the amount deposit faield
        /// </returns>
        public bool Deposit(long customerIdentity, double amount)
        {
            try
            {
                var getCustomer = (from customer in _dbContext.Customers
                                   where customer.CustomerIdentity == customerIdentity
                                   select customer).FirstOrDefault();
                if (getCustomer == null)
                    return false;
                else
                {
                    var getBalance = (from balance in _dbContext.AccountBalances
                                      where balance.AccountID == (from accounts in _dbContext.Accounts
                                                                  where accounts.CustomerID == getCustomer.CustomerID
                                                                  select accounts).FirstOrDefault().AccountID
                                      select balance).FirstOrDefault();
                    getBalance.AccountAmount += amount;
                    _dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        #endregion

        #region [Valid Amount Method]
        /// <summary>
        /// This method is to check if tha account have enough money to withdraw
        /// </summary>
        /// <param name="customerIdentity"></param>
        /// <param name="amount"></param>
        /// <returns>
        /// true tha account have enough money to withdraw
        /// false tha account have enough money to withdraw
        /// </returns>
        public bool ValidAmount(long customerIdentity, double amount)
        {
            try
            {
                var getCustomer = (from customer in _dbContext.Customers
                                   where customer.CustomerIdentity == customerIdentity
                                   select customer).FirstOrDefault();
                if (getCustomer == null)
                    return false;
                else
                {
                    var getBalance = (from balance in _dbContext.AccountBalances
                                      where balance.AccountID == (from accounts in _dbContext.Accounts
                                                                  where accounts.CustomerID == getCustomer.CustomerID
                                                                  select accounts).FirstOrDefault().AccountID
                                      select balance).FirstOrDefault();
                    
                    if(getBalance == null || getBalance.AccountAmount <= 0 || getBalance.AccountAmount < amount)
                       return false;

                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        #endregion

        #region [Withdraw Method]
        /// <summary>
        /// This method is to withdraw money from specific account
        /// </summary>
        /// <param name="customerIdentity"></param>
        /// <param name="amount"></param>
        /// <returns>
        /// true if the amount is withdraw success
        /// false if the amount withdraw faield
        /// </returns>
        public bool Withdraw(long customerIdentity, double amount)
        {
            try
            {
                var getCustomer = (from customer in _dbContext.Customers
                                   where customer.CustomerIdentity == customerIdentity
                                   select customer).FirstOrDefault();
                if (getCustomer == null)
                    return false;
                else
                {
                    var getBalance = (from balance in _dbContext.AccountBalances
                                      where balance.AccountID == (from accounts in _dbContext.Accounts
                                                                  where accounts.CustomerID == getCustomer.CustomerID
                                                                  select accounts).FirstOrDefault().AccountID
                                      select balance).FirstOrDefault();
                    getBalance.AccountAmount -= amount;
                    _dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        #endregion

    }
}
