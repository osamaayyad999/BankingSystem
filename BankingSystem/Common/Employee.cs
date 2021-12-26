using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public class Employee
    {
		public int EmployeeID { get; set; }
		public int DepartmentID { get; set; }
		public int RoleID { get; set; }
		public string EmployeeUsername { get; set; }
		public string EmployeePassword { get; set; }
		public string EmployeeEmail { get; set; }
		public bool EmployeeStatus { get; set; }
	}
}
