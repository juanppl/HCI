using HCI.WebApi.HciDbContext.Models;

namespace HCI.WebApi.Services
{
    public interface IEspecialidadService
    {
        Task<Especialidad> CrearEspecialidadAsync(Especialidad especialidad);
        Task<List<Especialidad>> ObtenerEspecialidadesAsync();
        Task<Especialidad> ObtenerEspecialidadPorIdAsync(int id);
        Task<bool> ActualizarEspecialidadAsync(Especialidad especialidad);
        Task<bool> EliminarEspecialidadAsync(int id);
    }
}
