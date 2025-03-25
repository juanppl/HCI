using HCI.WebApi.HciDbContext.Models;
using HCI.WebApi.Services.DTO;

namespace HCI.WebApi.Services
{
    public interface ITurnoService
    {
        Task<Turno> CrearTurnoAsync(TurnoDTO turno);
        Task<List<Turno>> ObtenerTurnosAsync();
        Task<Turno> ObtenerTurnoPorIdAsync(int id);
        Task<bool> ActualizarTurnoAsync(Turno turno);
        Task<bool> EliminarTurnoAsync(int id);
    }
}
