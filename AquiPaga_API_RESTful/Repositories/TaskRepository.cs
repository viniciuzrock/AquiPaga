using AquiPaga_API_RESTful.Models;
using AquiPaga_API_RESTful.Repositories.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace AquiPaga_API_RESTful.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        //private readonly string _connectionString;
        private readonly SqlConnection _sqlConnection;
        public TaskRepository(IConfiguration configuration)
        {
            //_connectionString = configuration.GetConnectionString("DataBase");
            _sqlConnection = new SqlConnection(configuration.GetConnectionString("DataBase"));
        }
        public async Task<List<TaskModel>> ListAsync()
        {
            const string sql = "SELECT * FROM Tasks";
            var tasks = await _sqlConnection.QueryAsync<TaskModel>(sql);
            return tasks.ToList();
        }
        public Task<TaskModel> AddAsync(TaskModel Task)
        {
            throw new NotImplementedException();
        }
    }
}
