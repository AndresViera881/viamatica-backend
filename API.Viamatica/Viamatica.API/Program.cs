using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Viamatica.Data;

var builder = WebApplication.CreateBuilder(args);
string MiCors = "MiCors";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ViamaticaDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MiCors,
                      builder =>
                      {
                          builder.AllowAnyHeader();
                          builder.AllowAnyOrigin();
                          builder.AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MiCors);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
