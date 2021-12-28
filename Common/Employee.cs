using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Employee
    {
		[Key]
		public int EmployeeID { get; set; }
		[ForeignKey("DepartmentID")]
		public int DepartmentID { get; set; }
		[ForeignKey("RoleID")]
		public int RoleID { get; set; }
		public string EmployeeUsername { get; set; }
		public string EmployeePassword { get; set; }
		public string EmployeeEmail { get; set; }
		public bool EmployeeStatus { get; set; }
	}
}
