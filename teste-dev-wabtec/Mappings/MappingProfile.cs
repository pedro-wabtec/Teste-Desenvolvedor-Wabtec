using AutoMapper;
using teste_dev_wabtec.Api.DTOs;
using teste_dev_wabtec.Api.Models;

namespace teste_dev_wabtec.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            #region ModelToDto
            CreateMap<TaskItem, TaskResponse>();
            #endregion
        }
    }
}
