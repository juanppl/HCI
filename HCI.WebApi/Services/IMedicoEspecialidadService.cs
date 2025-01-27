using HCI.WebApi.HciDbContext.Models;

namespace HCI.WebApi.Services
{
    public interface IMedicoEspecialidadService
    {
        Task<MedicoEspecialidad> CrearMedicoEspecialidadAsync(MedicoEspecialidad medicoEspecialidad);
        Task<List<MedicoEspecialidad>> ObtenerMedicoEspecialidadAsync();
        Task<MedicoEspecialidad> ObtenerMedicoEspecialidadPorIdAsync(int id);
        Task<bool> ActualizarMedicoEspecialidadAsync(MedicoEspecialidad medicoEspecialidad);
        Task<bool> EliminarMedicoEspecialidadAsync(int id);
    }
}
