using AquiPaga_API_RESTful.Models;
using AquiPaga_API_RESTful.Repositories.Interfaces;
using AquiPaga_API_RESTful.Resource;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
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
            try
            {
                const string sql = "SELECT * FROM Tasks";
                var tasks = await _sqlConnection.QueryAsync<TaskModel>(sql);
                return tasks.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<TaskModel> ListIdAsync(int id)
        {
            try
            {
                const string sql = "SELECT * FROM Tasks WHERE ID = @Id";
                var task = await _sqlConnection.QueryFirstOrDefaultAsync<TaskModel>(sql, new {Id = id});
                return task;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<TaskModel> AddAsync(TaskModel task)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(SaveTaskResource Task, int id)
        {
            try
            {
                TaskModel existingTask = await ListIdAsync(id);

                if (existingTask == null)
                {
                    return false;
                }

                existingTask.Name = Task.Name;
                existingTask.Description = Task.Description;
                existingTask.Status = Task.Status;

                const string sql = "UpdateTask";
                var parameters = new
                {
                    TaskId = existingTask.Id,
                    NewName = existingTask.Name,
                    NewDescription = existingTask.Description,
                    NewStatus = existingTask.Status
                };

                int rowsAffected = await _sqlConnection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
                return rowsAffected > 0;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> RemoveAsync(int id)
        {
            try
            {
                TaskModel existingTask = await ListIdAsync(id);

                if (existingTask == null)
                {
                    return false;
                }

                const string sql = "DELETE FROM Tasks WHERE ID = @Id";
                int rowsAffected = await _sqlConnection.ExecuteAsync(sql, new { Id = id });
                return rowsAffected > 0;
            }
            catch 
            {
                throw;
            }

        }
    }
}
