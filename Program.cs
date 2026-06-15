using bolnica_webapi.Data;
using bolnica_webapi.Services.Implementacije;
using bolnica_webapi.Services.Sucelja;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=bolnica.db"));

builder.Services.AddScoped<IPacijentServis, PacijentServis>();
builder.Services.AddScoped<IOdjelServis, OdjelServis>();

var app = builder.Build();

// Swagger uvijek uključen
app.UseSwagger();
app.UseSwaggerUI();

// Za Docker može i bez HTTPS redirekcije
// app.UseHttpsRedirection();

app.MapControllers();

app.Run();