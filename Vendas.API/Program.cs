using Microsoft.EntityFrameworkCore;
using Vendas.Application.Interfaces;
using Vendas.Application.Mappers;
using Vendas.Application.Services;
using Vendas.Domain.Interfaces;
using Vendas.Infra.Context;
using Vendas.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<VendasDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase")));

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IEstoqueRepository, EstoqueRepository>();
builder.Services.AddScoped<IEstoqueService, EstoqueService>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddAutoMapper(typeof(DTOToDomainProfile));
builder.Services.AddAutoMapper(typeof(DomainToDTO));
builder.Services.AddAutoMapper(typeof(DTOToDomain));

builder.Services.AddAutoMapper(typeof(DTOToDomainProfile));
builder.Services.AddAutoMapper(typeof(DomainToDTO));

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
