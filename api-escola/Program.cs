using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using api_escola.Models;
using api_escola.Repositories.IRepositories;
using api_escola.Repositories;
using api_escola.Services.IServices;
using api_escola.Services; // <- ajuste se o namespace for diferente

var builder = WebApplication.CreateBuilder(args);

// Injetando autoMappper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Configuração do DbContext com Pomelo e MySQL 8.0.42
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ProjetoP3Context>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 42)))
);

//Repositories
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<ITituloRepository, TituloRepository>();
builder.Services.AddScoped<IInstituicaoRepository, InstituicaoRepository>();
builder.Services.AddScoped<ITipoCursoRepository, TipoCursoRepository>();
builder.Services.AddScoped<ITipoDisciplinaRepository, TipoDisciplinaRepository>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
builder.Services.AddScoped<ICursaRepository, CursaRepository>();
builder.Services.AddScoped<ILecionaRepository, LecionaRepository>();

//Services
builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<IProfessorService, ProfessorService>();
builder.Services.AddScoped<ITituloService, TituloService>();
builder.Services.AddScoped<IInstituicaoService, InstituicaoService>();
builder.Services.AddScoped<ITipoCursoService, TipoCursoService>();
builder.Services.AddScoped<ITipoDisciplinaService, TipoDisciplinaService>();
builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IDisciplinaService, DisciplinaService>();
builder.Services.AddScoped<ICursaService,  CursaService>();
builder.Services.AddScoped<ILecionaService, LecionaService>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
