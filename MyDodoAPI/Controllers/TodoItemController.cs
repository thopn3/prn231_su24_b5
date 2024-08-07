using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDodoAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyDodoAPI.Controllers
{
    [Route("api/[controller]")]
    public class TodoItemController : Controller
    {
        private readonly TodoContext _context;
        public TodoItemController(TodoContext context)
        {
            _context = context;
        }

        // POST api/todoitem
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem item)
        {
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();
            // Tra 1 doi tuong todo vua luu vao db
            return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, item);
        }

        // GET: api/todoitem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetTodoItems(List<TodoItem> todos)
        {
            var result = await _context.TodoItems
                    .Select(t => new { ma = t.Id, ten = t.Name, tinhtrang = t.IsComplete ? "Hoan thanh" : "Chua hoan thanh" }).ToListAsync();
            return Ok(result);
        }

        // GET: api/todoitem/id
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var result = await _context.TodoItems.FindAsync(id);
            if (result != null)
                return Ok(result);
            return NotFound();
        }

    }
}

