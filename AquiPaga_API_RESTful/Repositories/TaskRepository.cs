﻿using AquiPaga_API_RESTful.Models;
using AquiPaga_API_RESTful.Repositories.Interfaces;
using Dapper;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<List<TaskModel>> ListIdAsync(int id)
        {
            try
            {
                const string sql = "SELECT * FROM Tasks WHERE ID = @Id";
                var tasks = await _sqlConnection.QueryAsync<TaskModel>(sql, new {Id = id});
                return tasks.ToList();
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

        public async Task<bool> UpdateAsync(TaskModel Task)
        {
            try
            {
                var parameters = new TaskModel{
                    Id = Task.Id,
                    Name = Task.Name,
                    Description = Task.Description,
                    Status = Task.Status
                };

                const string sql = "UPDATE Tasks SET Name = @Name, Description = @Description, Status = @Status WHERE Id = @Id";
                int rowsAffected = await _sqlConnection.ExecuteAsync(sql, parameters);
                return rowsAffected > 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> RemoveAsync(int id)
        {
            try
            {
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
