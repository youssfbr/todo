using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MeuTodo.Models;

namespace MeuTodo.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        public List<Todo> Get()
        {
            return new List<Todo>();
        }
    }
}
