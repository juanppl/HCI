using AutoMapper;
using HCI.WebApi.HciDbContext.Models;

namespace HCI.WebApi.Services.DTO
{
    public class CitaProfile : Profile
    {
        public CitaProfile() {
            CreateMap<Cita, ObtenerCitaOutput>();
            CreateMap<Usuario, UsuarioCitaOutput>();
            CreateMap<MedicoEspecialidad, MedicoEspecialidadOuput>();
        }
    }
}
