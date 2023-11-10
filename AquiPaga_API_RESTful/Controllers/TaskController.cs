using AquiPaga_API_RESTful.Models;
using AquiPaga_API_RESTful.Repositories;
using AquiPaga_API_RESTful.Repositories.Interfaces;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace AquiPaga_API_RESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        //private readonly string _connectionString;
        private readonly ITaskRepository _taskRepository;
        public TaskController(IConfiguration configuration, ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
            //_connectionString = configuration.GetConnectionString("DataBase");
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetAllAsync()
        {
            List<TaskModel> tasks = await _taskRepository.ListAsync();
            return Ok(tasks);
            //using (var sqlConnection = new SqlConnection(_connectionString))
            //{
            //const string sql = "SELECT * FROM Tasks";
            //var students = await sqlConnection.QueryAsync<TaskModel>(sql);
            //return Ok(students);
            //}
        }

        [HttpPost]
        public void PostAsync(TaskModel task)
        {
            Console.WriteLine(task);
            Console.WriteLine(task.Name);
            Console.WriteLine("Tarefa recebida.");
        }
    }
}
