using EscolaAPI.Infra.Context;
using EscolaAPI.Application;
using Microsoft.EntityFrameworkCore;
using EscolaAPI.Application.Services;
using EscolaAPI.Infra.Repositories;
using EscolaAPI.Configuration;
using BiliotecaAPI.Configuration;
using EscolaAPI.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwagger();
builder.Services.AddTransient<UsuarioService>();
builder.Services.AddTransient<AlunoService>();
builder.Services.AddTransient<TurmaService>();
builder.Services.AddTransient<ProfessorService>();
builder.Services.AddTransient<DisciplinaService>();
builder.Services.AddTransient<IDisciplinaRepositorio, DisciplinaRepositorio>();
builder.Services.AddTransient<IProfessorRepositorio, ProfessorRepositorio>();
builder.Services.AddTransient<IAlunoRepositorio, AlunoRepositorio>();
builder.Services.AddTransient<ITurmaRepositorio, TurmaRepositorio>();
builder.Services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddApplication();
var Configuration = builder.Configuration;
builder.Services.AddTokenConfiguration(Configuration);
string ConnectionString = Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<EscolaContext>(options => options.UseSqlServer(ConnectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
