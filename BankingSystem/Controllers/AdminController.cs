using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankingSystem
{
    
    public class AdminController : IAdminController
    {
        public AdminController() { }
        private string _Name;
        private string _Password;
        private string _Email;
        private int _Age;
        private double _Balance;
        private string _Type;
        private string _Gender;
        private uint _Id;
        private uint _Phone;
        private string _Status;
        private DateTime _CurrentDateTime;
        private DateTime _LastSeenDateTime;

        //AdminDAL adminDAL = AdminDAL.GetInstance();
        AdminDAL adminDAL = AdminDAL.GetInstance();
       // AdminController adminController = new AdminController();

        #region [Login method]
        /// <summary>
        /// /// this method search for the custmer account
        /// this method allow the user to login to his account, withdraw money, deposit money, show details if the account is exist in DB
        /// if the account does not exist show error message
        /// </summary>
        public void Login()
        {
            Account account = new Account();
            uint accNo;
            string password;
            Console.Clear();
            Console.WriteLine("Login page - Osama bank system\n");
            Drawline();
            Console.Write("Enter your account number: ");
            try
            {
                accNo = uint.Parse(Console.ReadLine());
                account = adminDAL.GetAccount(accNo);
                if (account != null)
                {
                    Console.WriteLine("Enter your Password: ");
                    try
                    {
                        AdminController adminController = new AdminController();
                        password = Console.ReadLine();
                        if (account.Password == password)
                        {
                            string state = "Coustmer who has Id = " + accNo +" and name = "+ account.Name+ " logged in his account at: " + DateTime.Now.ToString();
                            WriteAuditFile(state);
                            bool loginFlag = true;
                            while (loginFlag)
                            {
                                switch (adminController.loginMenu(account.Name, account.Gender))
                                {
                                    case 1:
                                        adminController.DepositMoney(account);
                                        break;
                                    case 2:
                                        adminController.WithdrawMoney(account);
                                        break;
                                    case 3:
                                        adminController.DisplayDetails(account);
                                        break;
                                    case 4:
                                        account.LastSeenDateTime = DateTime.Now;
                                        if (adminDAL.UpdateAccount(account) > 0)
                                        {
                                            Console.WriteLine("Thanxs for using our service.");
                                            loginFlag = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Can not logoff now!!");
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("\n");
                                        Console.WriteLine("Incorrect Option Please Try Again!");
                                        break;
                                }
                                if (loginFlag)
                                    Console.ReadLine();
                            }
                        }
                        else
                        {
                            
                            Console.WriteLine("The password you entered is incorrect!!");
                            string state = "Coustmer who has Id = " +accNo + " try to accsess his account but entered an invalid password at: " + DateTime.Now.ToString();
                            WriteAuditFile(state);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please Enter a password"!);
                    }

                }
                else
                {
                    Console.WriteLine("The account number: " + accNo + " you enterd does not exist in our system."
                        + "\nPlease check the account number and check again!");
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Please Enter correct formating for account number ");
            }
        }
        // this method is used to display the menu to the user when logged in
        // and read what option that user chose to do
        public int loginMenu(string name, string gender)
        {

            Console.Clear();
            Console.WriteLine("Welcome {0}. {1} in osama bank systemn\n", (gender[0] == 'M' || gender[0] == 'm') ? "Mr" : "Ms", name);
            Console.WriteLine("1. Deposit Money");
            Console.WriteLine("2. Withdraw Money");
            Console.WriteLine("3. Show My Account Details");
            Console.WriteLine("4. Logout");
            //Console.WriteLine("5. Tranfer Money"); // to remember it 
            Console.WriteLine("Enter your choice: ");
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                return 0;
            }
        }
        public void Drawline()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
        }
        #endregion


        #region [Signup method]

        /// <summary>
        /// this method is to create a new account
        /// this method makes validation for all data needed
        /// if all is right create a new account
        /// </summary>

        public void Signup()
        {   bool validate = false;
            Account account = new Account();
            double amount;
            
            try {
                Console.Clear();
                Console.WriteLine("Signup page - Osama bank system\n");
                Drawline();
                Console.Write("Enter your name: ");
                while (validate == false)
                {
                    _Name = Console.ReadLine();
                    validate = Regex.IsMatch(_Name, "^[A-Za-z]+$");
                    if (validate == false)
                        Console.WriteLine("Please Enter a valid Name: ");
                }
                validate = false;
                account.Name = _Name;


                Console.Write("Your Email: ");
                while (validate == false)
                {
                    _Email = Console.ReadLine();
                    validate = Regex.IsMatch(_Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                    if (validate == false)
                        Console.WriteLine("Please Enter a valid Email: ");
                }
                validate = false;
                account.Email = _Email;

                Console.Write("Your Id: ");
                while (validate == false)
                {
                    _Id = uint.Parse(Console.ReadLine());
                    validate = Regex.IsMatch(_Id.ToString(), @"^[0-9]+$");
                    if (validate == false)
                        Console.WriteLine("Please Enter a valid Id: ");
                }
                validate = false;
                account.Id = _Id;

                Console.Write("Your Password: ");
                while (validate == false)
                {
                    _Password = Console.ReadLine();
                    validate = Regex.IsMatch(_Password.ToString(), @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
                    if (validate == false)
                        Console.WriteLine("Your password must contains at least one Uppercase, lowercase, 8 character, and one number\nPlease Enter a valid Password: ");
                }
                validate = false;
                account.Password = _Password;

                Console.Write("Your Phone: ");
                while (validate == false)
                {
                    _Phone = uint.Parse(Console.ReadLine());
                    validate = Regex.IsMatch(_Phone.ToString(), @"^[0-9]+$");
                    if (validate == false)
                        Console.WriteLine("Enter a valid phone number");
                }
                validate = false;
                account.Phone = _Phone;

                Console.Write("Your Gender: ");
                while (validate == false)
                {
                    _Gender = Console.ReadLine();
                    validate = Regex.IsMatch(_Gender.ToLower(), @"^m(ale)?$|^f(emale)?$");
                    if (validate == false)
                        Console.WriteLine("Your gender must be (Male Or Female)!\nPlease Enter a valid Gender : ");
                }
                validate = false;
                account.Gender = _Gender;

                Console.Write("Your Age: ");
                while (validate == false)
                {
                    _Age = int.Parse(Console.ReadLine());
                    validate = Regex.IsMatch(_Age.ToString(), @"^\d+$");
                    if (validate == false)
                        Console.WriteLine("Enter a valid age: ");
                }
                validate = false;
                account.Age = _Age;

                Console.Write("Your Type (Current Or Saving): ");
                while (validate == false)
                {
                    _Type = Console.ReadLine();
                    validate = Regex.IsMatch(_Type, @"^c(urrent)?$|^s(aving)?$");
                    if (validate == false)
                        Console.WriteLine("Enter a valid Type (Current Or Saving): ");
                }
                validate = false;
                account.Type = _Type;

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
                account.Balance = _Balance;

                account.CurrentDateTime = DateTime.Now;
                account.LastSeenDateTime = DateTime.Now;
                account.Status = "open";
                Console.WriteLine("ooooooooooooooooooooooooooooooooooooooooo"+ account.Name);
                int create = adminDAL.CreateAccount(account);
                if (create == 0)
                    Console.WriteLine("You already have an account");
                else if (create == -1)
                    Console.WriteLine("Can not create account now, try again later!");
                else
                {
                    Console.WriteLine("Created account sucessfully!!");
                    string state = "Coustmer who has Id = " + _Id + " Created a new account at" + DateTime.Now.ToString();
                    WriteAuditFile(state);
                }


            }
            catch 
            {
                Console.WriteLine("Error in sign up page, try again later!");
            } 
            
        }
        #endregion

        #region [Deposit method]
        /// <summary>
        /// this method is to deposit a money from input account
        /// make the deposit process if the amount to deposit is valid
        /// </summary>
        /// <param name="account"></param>
        public void DepositMoney(Account account)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Welcome {0}. {1} in Deposit page systemn\n", (account.Gender[0] == 'M' || account.Gender[0] == 'm') ? "Mr" : "Ms", account.Name);
                Console.Write("Enter amount you want to deposit: ");
                double amount = double.Parse(Console.ReadLine());
                if (amount > 0)
                {
                    account.Balance += amount;
                    if (adminDAL.UpdateAccount(account) > 0)
                    {
                        Console.WriteLine("Successfully deposited {0} Nis, and your new balance become {1} Nis.", amount, account.Balance);
                        string state = "Coustmer who has Id = " + account.Id + " deposit " +amount+ " NIS to his account at: " + DateTime.Now.ToString();
                        WriteAuditFile(state);
                    }
                    else
                        Console.WriteLine("Error in deposit a money");
                }
                else
                {
                    Console.WriteLine("you must deposit a valid amount of money");
                    string state = "Coustmer who has Id = " + account.Id + " try to deposit invalid amount to his account at: " + DateTime.Now.ToString();
                    WriteAuditFile(state);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in deposit page");
                Console.Clear();
            }
        }
        #endregion

        #region [Withdraw method]
        /// <summary>
        /// this method is to deposit a money from input account
        /// make the withdraw process if the amount to withdraw is valid and the balance is enough
        /// </summary>
        /// <param name="account"></param>

        public void WithdrawMoney(Account account)
        {
            try {
                Console.Clear();
                Console.WriteLine("Welcome {0}. {1} in Withdraw page systemn\n", (account.Gender[0] == 'M' || account.Gender[0] == 'm') ? "Mr" : "Ms", account.Name);
                if (account.Balance > 0)
                {
                    Console.Write("Enter amount you want to withdraw: ");
                    double amount = double.Parse(Console.ReadLine());
                    if (amount > 0 && amount <= account.Balance)
                    {
                        account.Balance -= amount;
                        if (adminDAL.UpdateAccount(account) > 0)
                        {
                            Console.WriteLine("Successfully withdrawed {0} Nis from your account, and your new balance become {1} Nis.", amount, account.Balance);
                            string state = "Coustmer who has Id = " + account.Id + " withdraw " + amount + " NIS from his account at: " + DateTime.Now.ToString();
                            WriteAuditFile(state);
                        }
                        else
                            Console.WriteLine("Error in withdraw a money");
                    }
                    else
                    {
                        Console.WriteLine("you can not withdraw money");
                        string state = "Coustmer who has Id = " + account.Id + " try to withdraw invalid amount to his account at: " + DateTime.Now.ToString();
                        WriteAuditFile(state);
                    }
                }
                else
                {
                    Console.WriteLine("You can not withdraw a money because you don't hava a balnce!!");
                    string state = "Coustmer who has Id = " + account.Id + " try to withdraw money from his account at: " + DateTime.Now.ToString() + " ,but his account does not have a money ";
                    WriteAuditFile(state);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error in deposit page");
                Console.Clear();
            }
        }
        #endregion


        #region [Display details method]
        /// <summary>
        /// this method has an account variable as an input
        /// this method prints all data about the account
        /// </summary>
        /// <param name="account"></param>
        public void DisplayDetails(Account account)
        {
            Console.Clear();
            Console.WriteLine("Your Name is: " + account.Name);
            Console.WriteLine("Your Email is: " + account.Email);
            Console.WriteLine("Your Id is: " + account.Id);
            Console.WriteLine("Your Balance is: " + account.Balance);
            Console.WriteLine("Your Age is: " + account.Age);
            Console.WriteLine("Your Gender is: " + account.Gender);
            Console.WriteLine("Your phone" + account.Phone);
            Console.WriteLine("Account type: "+ account.Type);
            Console.WriteLine("Current date time: " + DateTime.Now.ToString());
            Console.WriteLine("Last seen date time: "+ account.LastSeenDateTime.ToString());
            
        }
        #endregion


        // this method is to write data to audit file
        public void WriteAuditFile (string str)
        {
            string path = @"C:\Users\oayyad\source\repos\BankingSystem\BankingSystem\audit.txt";
            string fileData = File.ReadAllText(path);
            fileData += "\n\n" + str;
            File.WriteAllText(path, fileData);
        }
    }
}
