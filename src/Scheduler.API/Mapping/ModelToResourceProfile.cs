using AutoMapper;
using Supermarket.API.Domain.Models;
using Supermarket.API.Resources;

namespace Supermarket.API.Mapping
{
    // ignore this, mapping was something i did in the beginning to experiment, in the last phase its not needed
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Employee, EmployeeResource>();
        }

    }
}
