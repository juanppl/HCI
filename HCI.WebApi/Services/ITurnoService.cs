using HCI.WebApi.HciDbContext.Models;

namespace HCI.WebApi.Services
{
    public interface ITurnoService
    {
        Task<Turno> CrearTurnoAsync(Turno turno);
        Task<List<Turno>> ObtenerTurnosAsync();
        Task<Turno> ObtenerTurnoPorIdAsync(int id);
        Task<bool> ActualizarTurnoAsync(Turno turno);
        Task<bool> EliminarTurnoAsync(int id);
    }
}
