using api_restful.config;
using api_restful.models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var stringConexao = "User Id=RM93705;Password=220976;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST =oracle.fiap.com.br)(PORT=1521)))(CONNECT_DATA=(SID = ORCL)))";
builder.Services.AddDbContext<Contexto>(options => options.UseOracle(stringConexao));
Console.WriteLine("Servidor iniciado");

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseEndpoints(routeBuilder =>
{
    routeBuilder.MapControllers();
});

app.Run();