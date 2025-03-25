namespace HCI.WebApi.HciDbContext
{
    using HCI.WebApi.HciDbContext.Models;
    using Microsoft.EntityFrameworkCore;

    public class HCIContext : DbContext
    {
        public HCIContext(DbContextOptions<HCIContext> options) : base(options)
        {
        }

        // Definimos las tablas correspondientes a las entidades
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<MedicoEspecialidad> MedicoEspecialidad { get; set; }  // Aquí cambiamos el nombre a "MedicoEspecialidad"
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Turno> Turnos { get; set; }

        // Configuración de relaciones y convenciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la tabla "Roles"
            modelBuilder.Entity<Rol>()
                .ToTable("Roles");

            modelBuilder.Entity<Rol>()
                .HasKey(r => r.IdRol);

            modelBuilder.Entity<Rol>()
                .Property(r => r.IdRol)
                .HasColumnName("id_rol");  // Nombre de columna

            modelBuilder.Entity<Rol>()
                .Property(r => r.NombreRol)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("nombre_rol");  // Nombre de columna

            modelBuilder.Entity<Rol>()
                .Property(r => r.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");  // Nombre de columna

            // Configuración de la tabla "Usuarios"
            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios");

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.IdUsuario);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.IdUsuario)
                .HasColumnName("id_usuario");  // Nombre de columna

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Nombre)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("nombre");  // Nombre de columna

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Apellido)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("apellido");  // Nombre de columna

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("email");  // Nombre de columna

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Telefono)
                .HasMaxLength(15)
                .HasColumnName("telefono");  // Nombre de columna

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");  // Nombre de columna

            modelBuilder.Entity<Usuario>()
                .Property(u => u.FechaRegistro)
                .HasColumnName("fecha_registro");  // Nombre de columna

            modelBuilder.Entity<Usuario>()
                .Property(u => u.IdRol)
                .HasColumnName("id_rol");  // Nombre de columna

            // Relación con la tabla "Roles"
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(u => u.IdRol)
                .HasConstraintName("FK__Usuarios__id_rol__628FA481");  // Clave foránea

            // Configuración de la tabla "Especialidades"
            modelBuilder.Entity<Especialidad>()
                .ToTable("Especialidades");
            modelBuilder.Entity<Especialidad>()
                .HasKey(e => e.IdEspecialidad);

            modelBuilder.Entity<Especialidad>()
                .Property(e => e.IdEspecialidad)
                .HasColumnName("id_especialidad");  // Nombre de columna

            modelBuilder.Entity<Especialidad>()
                .Property(e => e.NombreEspecialidad)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("nombre_especialidad");  // Nombre de columna

            modelBuilder.Entity<Especialidad>()
                .Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");  // Nombre de columna

            // Configuración de la tabla "MedicoEspecialidad"
            modelBuilder.Entity<MedicoEspecialidad>()
                .ToTable("Medico_Especialidad");

            modelBuilder.Entity<MedicoEspecialidad>()
                .HasKey(me => me.IdMedicoEspecialidad);

            modelBuilder.Entity<MedicoEspecialidad>()
                .Property(me => me.IdMedicoEspecialidad)
                .HasColumnName("id_medico_especialidad");  // Nombre de columna

            modelBuilder.Entity<MedicoEspecialidad>()
                .Property(me => me.IdUsuario)
                .HasColumnName("id_usuario");  // Nombre de columna

            modelBuilder.Entity<MedicoEspecialidad>()
                .Property(me => me.IdEspecialidad)
                .HasColumnName("id_especialidad");  // Nombre de columna

            modelBuilder.Entity<MedicoEspecialidad>()
                .Property(me => me.FechaIngreso)
                .HasColumnName("fecha_ingreso");  // Nombre de columna

            modelBuilder.Entity<MedicoEspecialidad>()
                .HasOne(me => me.Usuario)
                .WithMany(m => m.MedicoEspecialidad)
                .HasForeignKey(me => me.IdUsuario)
                .HasConstraintName("FK__Medico_Es__id_us__4222D4EF");  // Clave foránea

            modelBuilder.Entity<MedicoEspecialidad>()
                .HasOne(me => me.Especialidad)
                .WithMany(m => m.MedicoEspecialidad)
                .HasForeignKey(me => me.IdEspecialidad)
                .HasConstraintName("FK__Medico_Es__id_es__4316F928");  // Clave foránea

            // Configuración de la tabla "Citas"
            modelBuilder.Entity<Cita>()
                .ToTable("Citas");
            modelBuilder.Entity<Cita>()
                .HasKey(c => c.IdCita);

            modelBuilder.Entity<Cita>()
                .Property(c => c.IdCita)
                .HasColumnName("id_cita");  // Nombre de columna

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Paciente)
                .WithMany(c => c.Citas)
                .HasForeignKey(c => c.IdUsuario)
                .HasConstraintName("FK__Citas__id_pacien__45F365D3");  // Relacionamos con el id_usuario en la tabla Usuarios

            modelBuilder.Entity<Cita>()
                .Property(c => c.IdUsuario)
                .HasColumnName("id_usuario");  // Nombre de columna de la clave foránea para el paciente

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.MedicoEspecialidad)
                .WithMany(m => m.Citas)
                .HasForeignKey(c => c.IdMedicoEspecialidad)
                .HasConstraintName("FK__Citas__id_medico__46E78A0C");  // Clave foránea para médico

            modelBuilder.Entity<Cita>()
                .Property(c => c.IdMedicoEspecialidad)
                .HasColumnName("id_medico_especialidad");  // Nombre de columna de la clave foránea para el médico

            modelBuilder.Entity<Cita>()
                .Property(c => c.Motivo)
                .HasMaxLength(255)
                .HasColumnName("motivo");  // Nombre de columna

            modelBuilder.Entity<Cita>()
                .Property(c => c.Estado)
                .HasMaxLength(20)
                .HasColumnName("estado");  // Nombre de columna

            modelBuilder.Entity<Cita>()
                .Property(c => c.FechaCita)
                .HasColumnName("fecha_cita");  // Nombre de columna

            // Configuración de la tabla "Turnos"
            modelBuilder.Entity<Turno>()
                .ToTable("Turnos");
            modelBuilder.Entity<Turno>()
                .HasKey(t => t.IdTurno);

            modelBuilder.Entity<Turno>()
                .Property(t => t.IdTurno)
                .HasColumnName("id_turno");  // Nombre de columna

            modelBuilder.Entity<Turno>()
                .HasOne(t => t.MedicoEspecialidad)
                .WithMany(t => t.Turnos)
                .HasForeignKey(t => t.IdMedicoEspecialidad)
                .HasConstraintName("FK__Turnos__id_medic__49C3F6B7");  // Clave foránea

            modelBuilder.Entity<Turno>()
                .Property(t => t.IdMedicoEspecialidad)
                .HasColumnName("id_medico_especialidad");  // Nombre de columna de la clave foránea para el médico

            modelBuilder.Entity<Turno>()
                .Property(t => t.FechaTurno)
                .HasColumnName("fecha_turno");  // Nombre de columna

            modelBuilder.Entity<Turno>()
                .Property(t => t.FechaTurnoFin)
                .HasColumnName("fecha_turno_fin");

            modelBuilder.Entity<Turno>()
                .Property(t => t.Estado)
                .HasMaxLength(20)
                .HasColumnName("estado");  // Nombre de columna
        }
    }

}
