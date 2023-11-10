using AquiPaga_API_RESTful.Models;

namespace AquiPaga_API_RESTful.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> ListAsync();
        Task<TaskModel> AddAsync(TaskModel Task);
    }
}
