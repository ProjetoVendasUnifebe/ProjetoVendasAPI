using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;
using System.Data.SqlClient;
using Vendas.Application.Interfaces;
using Vendas.Application.Mappers;
using Vendas.Application.Services;
using Vendas.Domain.Interfaces.Dapper;
using Vendas.Domain.Interfaces.Repositories;
using Vendas.Infra.Context;
using Vendas.Infra.Dapper;
using Vendas.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do Entity Framework com PostgreSQL
builder.Services.AddDbContext<VendasDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase")));

builder.Services.AddScoped<IDbConnection>(provider =>
        new NpgsqlConnection(builder.Configuration.GetConnectionString("DataBase")));


// Registro de serviços e repositóriosNpgsqlConnection
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
builder.Services.AddScoped<IVendaRepository, VendaRepository>();
builder.Services.AddScoped<IVendaService, VendaService>();
builder.Services.AddScoped<IEstoque_ProdutoRepository, Estoque_ProdutoRepository>();
builder.Services.AddScoped<IEstoque_ProdutoService, Estoque_ProdutoService>();
builder.Services.AddScoped<IItensVendidosService, ItensVendidosService>();
builder.Services.AddScoped<IItensVendidosRepository, ItensVendidosRepository>();
builder.Services.AddScoped<IDapperVendas, DapperVendas>();

// Configuração do AutoMapper
builder.Services.AddAutoMapper(typeof(DTOToDomainProfile));
builder.Services.AddAutoMapper(typeof(DomainToDTO));
builder.Services.AddAutoMapper(typeof(DTOToDomain));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Ativar CORS
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
