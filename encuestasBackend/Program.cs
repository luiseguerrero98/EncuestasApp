using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using encuestasBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });
builder.Services.AddDbContext<ContextoDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        // .EnableSensitiveDataLogging() // Enable detailed logging
        // .LogTo(Console.WriteLine, LogLevel.Information) // Log to console
    );

builder.Services.AddScoped<EncuestaService>();
builder.Services.AddScoped<EncuestaCampoService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization(); 

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
