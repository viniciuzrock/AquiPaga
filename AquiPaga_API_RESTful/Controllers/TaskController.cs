using AquiPaga_API_RESTful.Models;
using AquiPaga_API_RESTful.Repositories;
using AquiPaga_API_RESTful.Repositories.Interfaces;
using AquiPaga_API_RESTful.Resource;
using AutoMapper;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AquiPaga_API_RESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        public TaskController(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetAllAsync()
        {
            try
            {
                List<TaskModel> tasks = await _taskRepository.ListAsync();
                if(tasks.Count == 0)
                {
                    return StatusCode(204, "Tarefa não encontrada.");
                }
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TaskModel>>> GetIdAsync(int id)
        {
            try
            {
                List<TaskModel> task = await _taskRepository.ListIdAsync(id);
                if (task.Count == 0)
                {
                    return NoContent();
                }
                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> PostAsync([FromBody] SaveTaskResource resource)
        {
            try
            {
                var task = _mapper.Map<SaveTaskResource,TaskModel>(resource);
                await _taskRepository.AddAsync(task);             
                return Ok(task);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] SaveTaskResource resource)
        {
            try
            {
                List<TaskModel> existingTask = await _taskRepository.ListIdAsync(id);

                if (existingTask.Count == 0)
                {
                    return NotFound();
                }

                existingTask[0].Name = resource.Name;
                existingTask[0].Description = resource.Description;
                existingTask[0].Status = resource.Status;

                bool success = await _taskRepository.UpdateAsync(existingTask[0]);

                if (success)
                {
                    return Ok(existingTask);
                }
                else
                {
                    return StatusCode(500, "Falha ao realizar a atualização.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao processar a solicitação: {ex.Message}");
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                List<TaskModel> existingTask = await _taskRepository.ListIdAsync(id);

                if (existingTask.Count == 0)
                {
                    return NotFound();
                }

                bool success = await _taskRepository.RemoveAsync(id);

                if (success)
                {
                    return Ok(existingTask);
                }
                else
                {
                    return StatusCode(500, "Falha ao realizar a atualização.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao processar a solicitação: {ex.Message}");
            }
        }
    }
}
