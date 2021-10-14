using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MeuTodo.Models;
using MeuTodo.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MeuTodo.ViewModels;
using System;

namespace MeuTodo.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var todos = await context
                .Todos
                .AsNoTracking()
                .ToListAsync();

            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] AppDbContext context, 
            [FromRoute] int id)
        {
            var todo = await context
                .Todos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return todo == null ? 
                NotFound() 
                : Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDbContext context,
            [FromBody]CreateTodoViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var todo = new Todo
            {
             //   Date = DateTime.Now,
             //   Done = false,
                Title = model.Title
            };

            try
            {
                await context.Todos.AddAsync(todo);
                await context.SaveChangesAsync();

                return Created($"v1/todos/{todo.Id}", todo);
            }
            catch(Exception e)
            {
                return BadRequest();
            }

        }

    }
}
