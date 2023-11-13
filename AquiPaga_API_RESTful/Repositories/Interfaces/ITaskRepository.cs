using AquiPaga_API_RESTful.Models;
using AquiPaga_API_RESTful.Resource;
using Microsoft.AspNetCore.Mvc;

namespace AquiPaga_API_RESTful.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> ListAsync();
        Task<TaskModel> ListIdAsync(int id);
        Task<TaskModel> AddAsync(TaskModel Task);
        Task<bool> UpdateAsync(SaveTaskResource Task, int id);
        Task<bool> RemoveAsync(int id);
    }
}
