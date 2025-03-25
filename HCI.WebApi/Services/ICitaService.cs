using HCI.WebApi.HciDbContext.Models;
using HCI.WebApi.Services.DTO;

namespace HCI.WebApi.Services
{
    public interface ICitaService
    {
        Task<Cita> CrearCitaAsync(CitaDTO cita);
        Task<List<Cita>> ObtenerCitasAsync();
        Task<List<ObtenerCitaOutput>> ObtenerCitaPorIdAsync(int id);
        Task<bool> ActualizarCitaAsync(Cita cita);
        Task<bool> EliminarCitaAsync(int id);
    }
}
