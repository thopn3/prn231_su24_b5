using System;
using Microsoft.EntityFrameworkCore;

namespace MyDodoAPI.Models
{
	// Class mo ta mo hinh CSDL, la 1 anh xa cua CSDL
	public class TodoContext: DbContext
	{
		public TodoContext(DbContextOptions<TodoContext> options): base(options)
		{
		}

		public DbSet<TodoItem> TodoItems { get; set; } = null;
	}
}

