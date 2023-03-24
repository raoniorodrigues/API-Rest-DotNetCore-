using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarefasBackEnd.Models;
using TarefasBackEnd.Repositories;

namespace TarefasBackEnd.Controllers
{

    [ApiController]
    [Route("tarefa")]
    public class TarefaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GET([FromServices] ITarefaReposity reposity) 
        {
            var tarefas = reposity.Read();
            return Ok(tarefas);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Tarefa model, [FromServices] ITarefaReposity reposity)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            reposity.Create(model);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Tarefa model, [FromServices] ITarefaReposity reposity)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            reposity.Update(new Guid(id), model);

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id, [FromServices] ITarefaReposity reposity)
        {
            reposity.Delete(new Guid(id));

            return Ok();
        }
    }
}