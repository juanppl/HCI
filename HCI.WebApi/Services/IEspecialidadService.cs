using HCI.WebApi.HciDbContext.Models;
using HCI.WebApi.Services.DTO;

namespace HCI.WebApi.Services
{
    public interface IEspecialidadService
    {
        Task<Especialidad> CrearEspecialidadAsync(EspecialidadDTO especialidad);
        Task<List<Especialidad>> ObtenerEspecialidadesAsync();
        Task<Especialidad> ObtenerEspecialidadPorIdAsync(int id);
        Task<bool> ActualizarEspecialidadAsync(EspecialidadDTO especialidad);
        Task<bool> EliminarEspecialidadAsync(int id);
    }
}
