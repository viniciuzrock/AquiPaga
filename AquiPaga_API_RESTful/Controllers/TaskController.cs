using AquiPaga_API_RESTful.Models;
using Microsoft.AspNetCore.Mvc;

namespace AquiPaga_API_RESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        public List<TaskModel> GetAllAsync()
        {
            return new List<TaskModel>();
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
