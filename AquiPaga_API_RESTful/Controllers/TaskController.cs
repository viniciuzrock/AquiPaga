using AquiPaga_API_RESTful.Models;
using AquiPaga_API_RESTful.Repositories;
using AquiPaga_API_RESTful.Repositories.Interfaces;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AquiPaga_API_RESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetAllAsync()
        {
            List<TaskModel> tasks = await _taskRepository.ListAsync();
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> PostAsync([FromBody]TaskModel task)
        {
            await _taskRepository.AddAsync(task);
            Console.WriteLine(task);
            Console.WriteLine(task.Name);
            Console.WriteLine("Tarefa recebida.");
            return Ok(task);
        }
    }
}
