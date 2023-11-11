using AquiPaga_API_RESTful.Models;
using Microsoft.AspNetCore.Mvc;

namespace AquiPaga_API_RESTful.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> ListAsync();
        Task<List<TaskModel>> ListIdAsync(int id);
        Task<TaskModel> AddAsync(TaskModel Task);
        Task<bool> UpdateAsync(TaskModel Task);
        Task<bool> RemoveAsync(int id);
    }
}
