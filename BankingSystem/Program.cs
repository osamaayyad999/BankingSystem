using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BankingSystem
{

    class BankSystem
    {
        public static void Main(string[] args)
        {
            AdminController adminController = new AdminController();
            BankSystem bankSystem = new BankSystem();

            while (true)
            {
                switch (bankSystem.MainMenu())
                {
                    case 1:
                        adminController.Login();
                        break;
                    case 2:
                        adminController.Signup();
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
            Console.WriteLine("1. Login (have an account)\n"
                + "2. Sign Up (open a new account)\n"
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

    }

} 