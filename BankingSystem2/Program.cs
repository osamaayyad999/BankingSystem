using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
namespace BankingSystem2
{

    class BankSystem
    {
        public static void Main(string[] args)
        {
            BankSystem bankSystem = new BankSystem();

            while (true)
            {
                switch (bankSystem.MainMenu())
                {
                    case 1:
                        bankSystem.AdminMenu();
                        break;
                    case 2:
                        bankSystem.TellerMenu();
                        break;
                    case 3:
                        Console.Clear();
                        bankSystem.About();
                        Console.WriteLine("\n");
                        Console.WriteLine("Press any key to go back to the main menu!");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("\n");
                        Console.Clear();
                        Console.WriteLine("Thanks for using our service!");
                        int milliseconds = 2000;
                        Thread.Sleep(milliseconds);
                        //System.Diagnostics.Process.Start(@"C:\Users\oayyad\source\repos\BankSystem\BankSystem\audit.txt");
                        Environment.Exit(0);

                        break;
                    default:
                        Console.WriteLine("\n");
                        Console.WriteLine("Incorrect Option Please Try Again!");
                        break;
                }
            }
        }
        #region [Main Menu method]
        /// <summary>
        /// this method is used to display the main menu to the custmers
        /// </summary>
        /// <returns>
        /// this method returns the number of choice that user entered
        /// </returns>
        public int MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Osama Bank System\n");
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("1. Admin\n"
                + "2. Teller\n"
                + "3. About Us\n"
                + "4. Exit\n");
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
        #endregion

        #region [about method]
        /// <summary>
        /// this method is to display details about app (bank system)
        /// </summary>
        public void About()
        {
            Console.WriteLine("Osama bank system");
            Console.WriteLine("Start developing in 13/12/2021");
        }
        #endregion

        #region [Admin Menu]
        public void AdminMenu()
        {
            AdminController adminController = new AdminController();
            Console.WriteLine("Welcome to Admin Menu\n\n"
                + "1- Create Account\n"
                + "2- Update Account\n"
                + "3- Delete Account\n"
                + "4- Back to Main Menu\n");
            int choice = int.Parse(Console.ReadLine());
            bool flag = true;

            while (flag)
            {
                switch (choice)
                {
                    case 1:
                        adminController.CreateAccount();
                        int milliseconds = 7000;
                        Thread.Sleep(milliseconds);
                        flag = false;
                        break ;
                    case 2:
                        adminController.UpdateAccount();
                        break;
                    case 3:
                        adminController.DeleteAccount();
                        break;
                    case 4:
                        flag = false;
                        break;
                    default: Console.WriteLine("Enter a valid choice!");
                        break;
                }
            }

        }
        #endregion

        #region [Teller Menu]
        public void TellerMenu()
        {
            TellerController tellerController = new TellerController();
            Console.WriteLine("Welcome to Teller Menu\n\n"
                + "1- Deposit\n"
                + "2- Withdraw\n"
                + "3- Back to Main Menu\n");
            int choice = int.Parse(Console.ReadLine());
            bool flag = true;

            while (flag)
            {
                switch (choice)
                {
                    case 1:
                        tellerController.Deposit();
                        break;
                    case 2:
                        tellerController.Withdraw();
                        break;
                    case 3:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Enter a valid choice!");
                        break;
                }
            }

        }
        #endregion

    }
} 