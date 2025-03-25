using HCI.WebApi.HciDbContext;
using HCI.WebApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IEspecialidadService, EspecialidadService>();
builder.Services.AddScoped<IMedicoEspecialidadService, MedicoEspecialidadService>();
builder.Services.AddScoped<ICitaService, CitaService>();
builder.Services.AddScoped<ITurnoService, TurnoService>();

builder.Services.AddDbContext<HCIContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("HCIConnection")));

builder.Services.AddCors(c => c.AddPolicy("MainPolicy", b =>
{
    b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
}));

//builder.Services.AddControllers().AddNewtonsoftJson(options =>
//{
//    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
//    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
//});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("MainPolicy");

app.Run();
