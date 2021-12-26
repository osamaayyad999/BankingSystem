using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public class Account
    {
        public Account() { }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public double Balance { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public uint Id { get; set; }
        public uint Phone { get; set; }
        public string Status { get; set; }

        public DateTime CurrentDateTime { get; set; }
        public DateTime LastSeenDateTime { get; set; }

        // gouid // 16 digit in hex
        public Account(string name, string pass, string email, int age, double balance, string type, string gender, uint id, uint phone, DateTime currentTime, DateTime lastSeenTime, string status)
        {
            this.Name = name;
            this.Password = pass;
            this.Email = email;
            this.Age = age;
            this.Balance = balance;
            this.Type = type;
            this.Gender = gender;
            this.Id = id;
            this.Phone = phone;
            this.CurrentDateTime = currentTime;
            this.LastSeenDateTime = lastSeenTime;
            this.Status = status;
        }

    }
}
