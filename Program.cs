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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();