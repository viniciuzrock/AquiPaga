using AquiPaga_API_RESTful.Models;
using AquiPaga_API_RESTful.Resource;
using AutoMapper;

namespace AquiPaga_API_RESTful.Mapping
{
    public class TaskMapping : Profile
    {
        public TaskMapping() 
        {
            CreateMap<SaveTaskResource, TaskModel>();
        }
    }
}
