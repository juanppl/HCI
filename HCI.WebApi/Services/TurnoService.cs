﻿using HCI.WebApi.HciDbContext.Models;
using HCI.WebApi.HciDbContext;
using Microsoft.EntityFrameworkCore;
using HCI.WebApi.Services.DTO;

namespace HCI.WebApi.Services
{
    public class TurnoService : ITurnoService
    {
        private readonly HCIContext _context;

        public TurnoService(HCIContext context)
        {
            _context = context;
        }

        // Crear un nuevo Turno
        public async Task<Turno> CrearTurnoAsync(TurnoDTO turno)
        {
            var newTurno = new Turno
            {
                IdMedicoEspecialidad = turno.IdMedicoEspecialidad,
                FechaTurno = turno.FechaTurno,
                FechaTurnoFin = turno.FechaTurnoFin,
                Estado = "OK"
            };
            _context.Turnos.Add(newTurno);
            await _context.SaveChangesAsync();
            return newTurno;
        }

        // Obtener todos los Turnos
        public async Task<List<Turno>> ObtenerTurnosAsync()
        {
            return await _context.Turnos.Include(t => t.MedicoEspecialidad).ToListAsync();
        }

        // Obtener un Turno por ID
        public async Task<Turno> ObtenerTurnoPorIdAsync(int id)
        {
            return await _context.Turnos.Include(t => t.MedicoEspecialidad)
                                        .FirstOrDefaultAsync(t => t.IdTurno == id);
        }

        // Actualizar un Turno
        public async Task<bool> ActualizarTurnoAsync(Turno turno)
        {
            _context.Turnos.Update(turno);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        // Eliminar un Turno
        public async Task<bool> EliminarTurnoAsync(int id)
        {
            var turno = await ObtenerTurnoPorIdAsync(id);
            if (turno == null) return false;

            _context.Turnos.Remove(turno);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
