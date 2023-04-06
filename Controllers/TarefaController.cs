using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using TarefasBackEnd.Models;
using TarefasBackEnd.Repositories;

namespace TarefasBackEnd.Controllers
{
    [Authorize]
    [ApiController]
    [Route("tarefa")]
    public class TarefaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GET([FromServices] ITarefaReposity reposity) 
        {
            var id = new Guid(User.Identity.Name);
            var tarefas = reposity.Read(id);
            return Ok(tarefas);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Tarefa model, [FromServices] ITarefaReposity reposity)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            model.UsuarioId = new Guid(User.Identity.Name);

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