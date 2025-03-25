using AutoMapper;
using HCI.WebApi.HciDbContext.Models;

namespace HCI.WebApi.Services.DTO
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile() {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
