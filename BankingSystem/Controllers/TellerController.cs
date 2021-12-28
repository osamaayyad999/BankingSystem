using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public class TellerController : ITellerController
    {
        public void Deposit()
        {
            TellerDAL tellerDAL = TellerDAL.GetInstance();
         
            Console.WriteLine("Enter customer identity: ");
            long identity = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter amount to deposit: ");
            double amount = double.Parse(Console.ReadLine());

            
            if (tellerDAL.Deposit(identity, amount) == true)
                Console.WriteLine("Deposit is sucess");
            else
                 Console.WriteLine("Error in deposit");

        }

        public void Withdraw()
        {
            TellerDAL tellerDAL = TellerDAL.GetInstance();

            Console.WriteLine("Enter customer identity: ");
            long identity = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter amount to withdraw: ");
            double amount = double.Parse(Console.ReadLine());

            if (tellerDAL.ValidAmount(identity, amount))
                if (tellerDAL.Deposit(identity, amount) == true)
                    Console.WriteLine("Withdraw is sucess");
                else
                    Console.WriteLine("Error in withdraw");
            else Console.WriteLine("Don't have enough balance");
        }
    }
}
