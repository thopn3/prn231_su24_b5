using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCodeFirstHR.Models
{
	public class Employee
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long EmployeeId { set; get; }
		public string FirstName { set; get; }
		public string LastName { set; get; }
		public string Email { set; get; }
		public string PhoneNumber { set; get; }
		public DateTime DateOfBirth { set; get; }
		public bool Gender { set; get; }
	}
}

