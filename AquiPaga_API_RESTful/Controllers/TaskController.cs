using AquiPaga_API_RESTful.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace AquiPaga_API_RESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly string _connectionString;
        public TaskController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DataBase");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const string sql = "SELECT * FROM Tasks";
                var students = await sqlConnection.QueryAsync<TaskModel>(sql);;
                return Ok(students);
            }
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
