using Microsoft.EntityFrameworkCore;
using SurvivorWebApiEF.Context;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var cs = builder.Configuration.GetConnectionString("defaultConnection");

builder.Services.AddDbContext<SurvivorDbContext>(options => options.UseNpgsql(cs));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.UseAuthorization();

app.Run();

