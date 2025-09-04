using Microsoft.EntityFrameworkCore;
using Slat.API.Server;
using Slat.API.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//this is a scoped service,
//ErrorMessage: unable to resolve service 

builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<LecturrerService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), migration => migration.MigrationsAssembly("Slat.API.Server")));
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

app.Run();
