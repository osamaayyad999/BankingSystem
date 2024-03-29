﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public class AdminDAL : IAdminDAL
    {
        private DataDbContext _dbContext = new DataDbContext();
        private static AdminDAL AdminDALInstance = null;
        private static object lockObj = new object();

       // public AdminDAL() { }
        private AdminDAL() { }

        // this method is used to return one instance of class
        public static AdminDAL GetInstance()
        {
            if (AdminDALInstance == null)
            {
                lock (lockObj)
                {
                    if (AdminDALInstance == null)
                    {
                        AdminDALInstance = new AdminDAL();
                    }
                }
            }
            return AdminDALInstance;
        }


        public Guid AddCustomer (Customer customer, AccountD accountD, AccountBalance accountBalance)
        {
            try {
                /*var allCustomers = _dbContext.Customers.Select(c => c).ToList();
                foreach (Customer cust in allCustomers)
                {
                    if (cust.CustomerID == customer.CustomerID)
                        return new Guid();
                }*/

                _dbContext.Customers.Add(customer);
                _dbContext.SaveChanges();

                _dbContext.Accounts.Add(accountD);
                _dbContext.SaveChanges();

                accountBalance.AccountID = accountD.AccountID;
                _dbContext.AccountBalances.Add(accountBalance);
                _dbContext.SaveChanges();
                return customer.CustomerID;
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.ToString());
                return new Guid();
            }   
            
        }

        public bool UpdateCustomer (Customer customer, AccountD accountD, AccountBalance accountBalance)
        {
            try {

                Console.WriteLine(customer.CustomerIdentity);

                var getCustomer = from cust in _dbContext.Customers
                                  select cust;
                /*var getCustomer = (from cust in _dbContext.Customers
                             where cust.CustomerIdentity == customer.CustomerIdentity
                             select cust).FirstOrDefault();*/

                if (getCustomer.Count() == 0)
                {
                    return false;
                }   
                else
                {
                    var CustomerBalance = (from customers in _dbContext.Customers
                                           from accounts in _dbContext.Accounts
                                           from balances in _dbContext.AccountBalances
                                           where customers.CustomerIdentity == customer.CustomerIdentity &&
                                           accounts.CustomerID == customer.CustomerID
                                           && balances.AccountID == accounts.AccountID
                                           select new { customers, accounts, balances }).FirstOrDefault();
                    if (CustomerBalance != null)
                    {
                        CustomerBalance.customers.CustomerPhone = customer.CustomerPhone;
                        CustomerBalance.accounts.AccountType = accountD.AccountType;
                        CustomerBalance.balances.AccountAmount = accountBalance.AccountAmount;
                    }
                }
                

                return true;

            }
            catch (Exception ex){
                // Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.InnerException.Message.ToString());
                return false;
            }

        }
       
        public bool DeleteCustomer (long customerIdentity)
        {
            try {
                var CustomerStatus = (from customers in _dbContext.Customers
                                      from accounts in _dbContext.Accounts
                                      from balances in _dbContext.AccountBalances
                                      where customers.CustomerIdentity == customerIdentity &&
                                      accounts.CustomerID == customers.CustomerID
                                      && balances.AccountID == accounts.AccountID
                                      select new { customers, accounts, balances }).FirstOrDefault();
                if (CustomerStatus != null)
                {
                    CustomerStatus.balances.AccountAmountStatus = false;
                    CustomerStatus.accounts.AccountStatus = false;
                    CustomerStatus.customers.CustomerStatus = false;
                    _dbContext.SaveChanges();
                    return true;
                }

                return false;


            }
            catch (Exception ex) { 
                Console.WriteLine(ex.ToString());
                return false;
            }

            
        }
        
    }
}
