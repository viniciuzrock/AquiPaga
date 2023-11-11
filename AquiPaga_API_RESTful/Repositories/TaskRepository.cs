using AquiPaga_API_RESTful.Models;
using AquiPaga_API_RESTful.Repositories.Interfaces;
using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AquiPaga_API_RESTful.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly SqlConnection _sqlConnection;
        public TaskRepository(IConfiguration configuration)
        {
            _sqlConnection = new SqlConnection(configuration.GetConnectionString("DataBase"));
        }
        public async Task<List<TaskModel>> ListAsync()
        {
            const string sql = "SELECT * FROM Tasks";
            var tasks = await _sqlConnection.QueryAsync<TaskModel>(sql);
            return tasks.ToList();
        }
        public async Task<TaskModel> AddAsync(TaskModel task)
        {
            var parameters = new 
            {
                task.Name,
                task.Description,
                task.Status,
            };

            const string sql = "INSERT INTO Tasks (Name, Description, Status) VALUES (@Name, @Description, @Status); SELECT SCOPE_IDENTITY();";
            int taskId = await _sqlConnection.ExecuteScalarAsync<int>(sql, parameters);

            task.Id = taskId;

            return task;
        }
    }
}
