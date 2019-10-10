using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ListaDeTarefas.Data;
using ListaDeTarefas.Domain.Interfaces;
using ListaDeTarefas.Model;

namespace ListaDeTarefas.Controllers
{

    /// <summary>
    /// Api de retorno das tarefas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly ITarefaService _tarefaService;

        /// <inheritdoc />
        public TarefaController(ApiContext context, ITarefaService tarefaService)
        {
            _context = context;
            _tarefaService = tarefaService;
        }

        /// <summary>
        /// Retorna todas as tarefas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefas()
        {
            return Ok(await _tarefaService.GetAllAsync());
        }

        /// <summary>
        /// Retorna uma tarefa filtrando pelo ID
        /// </summary>
        /// <param name="id"> Id da tarefa</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetTarefa(Guid id)
        {
            var tarefa = await _tarefaService.FindAsync(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return tarefa;
        }


        /// <summary>
        /// Altera os dados da tarefa
        /// </summary>
        /// <param name="id"> Id da Tarefa</param>
        /// <param name="tarefa">Objeto da tarefa a ser alterada</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarefa(Guid id, Tarefa tarefa)
        {
            if (id != tarefa.Id)
            {
                return BadRequest();
            }

            _tarefaService.Update(tarefa);

            try
            {
                await _tarefaService.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Cria uma nova tarefa 
        /// </summary>
        /// <param name="tarefa"> Id da tarefa</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Tarefa>> PostTarefa(Tarefa tarefa)
        {
            tarefa.StatusTarefa = StatusTarefa.Ativa;
            tarefa.DataCriacao = DateTime.Now;
            await _tarefaService.AddAsync(tarefa);
            await _tarefaService.SaveChangesAsync();

            return CreatedAtAction("GetTarefa", new { id = tarefa.Id }, tarefa);
        }


        /// <summary>
        /// Exclui a tarefa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tarefa>> DeleteTarefa(Guid id)
        {
            var tarefa = await _tarefaService.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            _tarefaService.Remove(tarefa);
            await _tarefaService.SaveChangesAsync();

            return tarefa;
        }

        private bool TarefaExists(Guid id)
        {
            return _tarefaService.Any(e => e.Id == id);
        }
    }
}
