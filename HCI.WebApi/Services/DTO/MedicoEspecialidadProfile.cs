using AutoMapper;
using HCI.WebApi.HciDbContext.Models;

namespace HCI.WebApi.Services.DTO
{
    public class MedicoEspecialidadProfile : Profile
    {
        public MedicoEspecialidadProfile()
        {
            CreateMap<MedicoEspecialidad, MedicoEspecialidadDTO>().ReverseMap();
            CreateMap<Especialidad, EspecialidadDTO>().ReverseMap();
        }
    }
}
