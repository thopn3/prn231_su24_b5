using System;
using Microsoft.EntityFrameworkCore;

namespace MyCodeFirstHR.Models
{
	public class HRContext: DbContext
	{
		public HRContext(DbContextOptions options):base(options)
		{
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			// Khoi tao du lieu ban dau cho bang Employees
			modelBuilder.Entity<Employee>().HasData(
				new Employee
				{
					EmployeeId = 1,
					FirstName = "Tho",
					LastName = "Pham Ngoc",
					Email = "thopn3@fpt.edu.vn",
					PhoneNumber = "099999999",
					DateOfBirth = new DateTime(2009, 10, 20),
					Gender = true
				},
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Huong",
                    LastName = "Tran Thu",
                    Email = "huongtt@fpt.edu.vn",
                    PhoneNumber = "098888888",
                    DateOfBirth = new DateTime(2005, 5, 15),
                    Gender = false
                }
            );
        }

        public DbSet<Employee> Employees { set; get; }
	}
}

