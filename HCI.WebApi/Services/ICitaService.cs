using HCI.WebApi.HciDbContext.Models;

namespace HCI.WebApi.Services
{
    public interface ICitaService
    {
        Task<Cita> CrearCitaAsync(Cita cita);
        Task<List<Cita>> ObtenerCitasAsync();
        Task<Cita> ObtenerCitaPorIdAsync(int id);
        Task<bool> ActualizarCitaAsync(Cita cita);
        Task<bool> EliminarCitaAsync(int id);
    }
}
