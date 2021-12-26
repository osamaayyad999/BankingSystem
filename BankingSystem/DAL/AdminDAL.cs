using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public class AdminDAL : IAdminDAL
    {

        private List<Account> accounts = new List<Account>();
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

        #region [Create Account]

        /// <summary>
        /// this method is to create a new account that accept Account as a parameter
        /// </summary>
        /// <param name="account"></param>
        /// <returns>
        /// return 0 if account is already exist
        /// return id if account is created
        /// return -1 if there is a problem
        /// </returns>
        public int CreateAccount(Account account)
        {   
            //List<Account> accountsC = new List<Account>();   

            try
            {
                ReadData();
               // Console.WriteLine(account.Id);
                if (accounts != null)
                {
                    foreach (Account accnt in accounts)
                    {
                        if (accnt.Id == account.Id)
                            return 0;
                    }
                }

                accounts.Add(account);
                //accounts!.Add(account);
                SavaData();
             
                return (int)account.Id;
            }
            catch (Exception ex)
            {
                return -1;
            }
            
        }
        #endregion

        #region [Delete Data]
        /// <summary>
        /// this account is to make account status is closed
        /// accept Account as a parameter
        /// </summary>
        /// <param name="account"></param>
        /// <returns>
        /// return id if the status changed to closed
        /// return 0 if the account does not exist in DB
        /// return -1 if there is a problem
        /// </returns>
        public int DeleteAccount(Account account)
        {
            //List<Account> accountsD = new List<Account>();  
            
            try
            {
                ReadData();
                foreach (Account accnt in accounts)
                {
                    if (accnt.Id == account.Id)
                    {
                        account.Status = "close";
                        SavaData();
                        return (int)account.Id;
                    }
                        
                }
                return 0;

            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        #endregion

        #region [Update Data]
        /// <summary>
        /// this method is to update account data when custmed make a deposit or withdraw a mobew
        /// accept a Account as a variable
        /// </summary>
        /// <param name="account"></param>
        /// <returns>
        /// return id if the account is updated
        /// return 0 if the account does not exist
        /// return -1 if there is a problem
        /// </returns>
        public int UpdateAccount(Account account)
        {
            try
            {
                //List<Account> accountsU = new List<Account>();
                ReadData();
                int i = 0;
                foreach (Account accnt in accounts)
                {
                    if (accnt.Id == account.Id)
                    {
                        accounts[i] = account;
                        SavaData();
                        return (int)account.Id;
                    }
                    i++; 
                }
                return 0;

            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        #endregion

        // this method accept id as an input then return account who has this id
        // if the account doesnot exist return null
        public Account GetAccount(uint id)
        {
            //List<Account> accountList = new List<Account>();
            int i = 0;
            ReadData();
            if(accounts != null)
                foreach (Account accnt in accounts)
                {
                    if (accounts[i].Id == id && accounts[i].Status == "open")
                    {
                        return accounts[i];
                    }
                    i++;
                }
            return null;
        }

        #region [Save Data]
        // this method is used to write data on JSON file
        public void SavaData()
        {
            try
            {
                File.WriteAllText(@"C:\Users\oayyad\source\repos\BankingSystem\BankingSystem\accountsData.json", JsonConvert.SerializeObject(accounts));
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("Can not read data now, please try again later!!");
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
        #endregion

        #region [Read Data]
        // this method is used to read all data from json file
        public void ReadData()
        {
            try
            {
                string json = File.ReadAllText(@"C:\Users\oayyad\source\repos\BankingSystem\BankingSystem\accountsData.json");
                var accountList = JsonConvert.DeserializeObject<List<Account>>(json);
                accounts = accountList;
                //return accountList; 
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("Can not read data now, please try again later!!");
                Console.WriteLine(e.Message);
                Console.ReadKey();
                //return null;
            }
        }
        #endregion

    }
}
