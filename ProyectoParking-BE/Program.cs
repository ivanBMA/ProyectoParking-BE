using Microsoft.EntityFrameworkCore;
using ProyectoParkingServices;
using ProyectoParkingServices.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ParkingContext>(options =>
{
    options.UseSqlServer("Data Source=ws16;Initial Catalog=Parking;User ID=emoros;password=Inicam10.;TrustServerCertificate=True");
});

builder.Services.AddScoped<ICocheService, CocheService>();
builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IDistribucionPlazaService, DistribucionPlazasService>();
builder.Services.AddScoped<IParkingsService, ParkingsService>();
builder.Services.AddScoped<IPlazasService, PlazasServices>();
builder.Services.AddScoped<IPreciosService, PrecioService>();
builder.Services.AddScoped<IRegistroPlazaService, RegistroPlazaService>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();
