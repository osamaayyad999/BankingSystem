//using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Common;
using DAL;

namespace Controllers
{
    
    public class AdminController : IAdminController
    {
        public AdminController() { }
        private string _Name;
        private string _Email;
        private int _Age;
        private double _Balance;
        private string _Type;
        private string _Gender;
        private int _Identity;
        private long _Phone;
        private string _Status;
        private DateTime _CurrentDateTime;
        private DateTime _LastSeenDateTime;

        AdminDAL adminDAL = AdminDAL.GetInstance();




        #region [Create Account method]

        /// <summary>
        /// this method is to create a new customer account
        /// this method makes validation for all data needed
        /// if all is right create a new account in DB
        /// </summary>

        public void CreateAccount()
        {
            bool validate = false;
            //Customer customer;
            
            double amount;

            try
            {
                Console.Clear();
                Console.WriteLine("Create Account page - Osama bank system\n");
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.Write("Enter your Name: ");
                while (validate == false)
                {
                    _Name = Console.ReadLine();
                    validate = Regex.IsMatch(_Name, "^[A-Za-z]+$");
                    if (validate == false)
                        Console.WriteLine("Please Enter a valid Name: ");
                }
                validate = false;

                Console.Write("Your Email: ");
                while (validate == false)
                {
                    _Email = Console.ReadLine();
                    validate = Regex.IsMatch(_Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                    if (validate == false)
                        Console.WriteLine("Please Enter a valid Email: ");
                }
                validate = false;

                Console.Write("Your Identity: ");
                while (validate == false)
                {
                    _Identity = int.Parse(Console.ReadLine());
                    validate = Regex.IsMatch(_Identity.ToString(), @"^\d{9}$");
                    if (validate == false)
                        Console.WriteLine("Please Enter a valid Identity: ");
                }
                validate = false;

                Console.Write("Your Phone: ");
                while (validate == false)
                {
                    _Phone = int.Parse(Console.ReadLine());
                    validate = Regex.IsMatch(_Phone.ToString(), @"^\d{10}$");
                    if (validate == false)
                        Console.WriteLine("Enter a valid phone number");
                }
                validate = false;
                
                Console.Write("Your Gender: ");
                while (validate == false)
                {
                    _Gender = Console.ReadLine();
                    validate = Regex.IsMatch(_Gender.ToLower(), @"^m(ale)?$|^f(emale)?$");
                    if (validate == false)
                        Console.WriteLine("Your gender must be (Male Or Female)!\nPlease Enter a valid Gender : ");
                }
                validate = false;
          
                Console.Write("Your Type (Current Or Saving): ");
                while (validate == false)
                {
                    _Type = Console.ReadLine();
                    validate = Regex.IsMatch(_Type, @"^c(urrent)?$|^s(aving)?$");
                    if (validate == false)
                        Console.WriteLine("Enter a valid Type (Current Or Saving): ");
                }
                validate = false;

                Console.Write("Enter amount to deposit: ");
                while (validate == false)
                {
                    _Balance = double.Parse(Console.ReadLine());
                    if (_Balance > 0)
                        validate = true;
                    else
                        Console.Write("Please enter a valid amount to deposit (>0): ");
                }
                validate = false;


                Guid guid = Guid.NewGuid();
                //int cID = int.Parse(guid.ToString());
                Customer customer = new Customer { CustomerID = guid, CustomerIdentity = _Identity, CustomerGender = _Gender, CustomerName = _Name, CustomerEmail = _Email, CustomerPhone = _Phone, CustomerStatus = true};
                AccountD accountD = new AccountD { AccountStatus = true, AccountType = _Type, AccountCreateTime = DateTime.Now.ToString(), CustomerID = guid};
                AccountBalance balanceD = new AccountBalance { AccountAmount = _Balance, AccountAmountStatus = true};


                Guid createGuid = adminDAL.AddCustomer(customer, accountD, balanceD);
                if (createGuid == new Guid())
                    Console.WriteLine("You already have an account");
                else
                {
                    Console.WriteLine("Created account sucessfully!! ==> Id = " + createGuid.ToString());
                    string state = "Coustmer who has Id = " + createGuid.ToString() + " Created a new account at" + DateTime.Now.ToString();
                }


            }
            catch
            {
                Console.WriteLine("Error in sign up page, try again later!");
            }

        }
        #endregion

        #region [Update Account]
        public void UpdateAccount()
        {
            try
            {
                bool validate = false;
                long identity;
                Console.WriteLine("Enter Identity for customer that you need to update: ");
                identity = long.Parse(Console.ReadLine());
                /*while (validate == false)
                {
                    identity = long.Parse(Console.ReadLine());
                    validate = Regex.IsMatch(_Identity.ToString(), @"^\d{9}$");
                    if (validate == false)
                        Console.WriteLine("Please Enter a valid Identity: ");
                    
                }*/


                validate = false;
                Console.Write("New Phone Number is: ");
                while (validate == false)
                {
                    _Phone = int.Parse(Console.ReadLine());
                    validate = Regex.IsMatch(_Phone.ToString(), @"^\d{10}$");
                    if (validate == false)
                        Console.WriteLine("Enter a valid phone number");
                }
                validate = false;

                Console.Write("Update Type To (Current Or Saving): ");
                while (validate == false)
                {
                    _Type = Console.ReadLine();
                    validate = Regex.IsMatch(_Type, @"^c(urrent)?$|^s(aving)?$");
                    if (validate == false)
                        Console.WriteLine("Enter a valid Type (Current Or Saving): ");
                }
                validate = false;

                Console.Write("Enter New Balance: ");
                while (validate == false)
                {
                    _Balance = double.Parse(Console.ReadLine());
                    if (_Balance > 0)
                        validate = true;
                    else
                        Console.Write("Please enter a valid amount to deposit (>0): ");
                }
                validate = false;

                
                Customer customer = new Customer { CustomerStatus = true, CustomerPhone = _Phone, CustomerIdentity = identity};
                AccountD accountD = new AccountD { AccountStatus = true, AccountType = _Type};
                AccountBalance accountBalance = new AccountBalance { AccountAmount = _Balance};

                bool update = adminDAL.UpdateCustomer(customer, accountD, accountBalance);
                if (update == false)
                    Console.WriteLine("Error in update customer");
                else
                    Console.WriteLine("Customer data updated sucessfully");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        #endregion


        #region [Delete Account]
        public void DeleteAccount()
        {
            try {
                
                bool validate = false;
                long identity;
                Console.WriteLine("Enter Identity for customer that you need to delete: ");
                while (validate == false)
                {
                    identity = long.Parse(Console.ReadLine());
                    validate = Regex.IsMatch(_Identity.ToString(), @"^\d$");
                    if (validate == false)
                        Console.WriteLine("Please Enter a valid Identity: ");
                    else
                    {
                        if (adminDAL.DeleteCustomer(identity) == true)
                            Console.WriteLine("Customer Account is inactive");
                        else Console.WriteLine("Error in inactive account!!");
                        break;
                    }
                }

                validate = false;
                //bool a = adminDAL.DeleteCustomer(identity);
                /*if (adminDAL.DeleteCustomer(identity) == true)
                    Console.WriteLine("Customer Account is inactive");
                else Console.WriteLine("Error in inactive account!!");*/
                
            }
            catch (Exception ex)
            {
                Console.WriteLine (ex.ToString());
            }

        }
        #endregion


    }
}
