using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MeuTodo.Models;
using MeuTodo.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MeuTodo.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] AppDbContext context)
        {
            var todos = await context
                .Todos
                .AsNoTracking()
                .ToListAsync();

            return Ok(todos);
        }
    }
}
