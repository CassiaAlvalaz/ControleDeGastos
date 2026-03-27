using ControleDeGastos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ControleDeGastos.Domain.Interface;
using ControleDeGastos.Infrastructure.Repositoty;
using ControleDeGastos.Application.Interface;
using ControleDeGastos.Application.Service;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

/// <summary>
/// Conversão dos Enums Tipo e Finalidade para texto.
/// </summary>
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/// <summary>
/// Apontamento string de conexão para criação de banco de dados usando SQLServer.
/// </summary>
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"),
        b => b.MigrationsAssembly("ControleDeGastos.Infrastructure"));
});

builder.Services.AddScoped<IPessoa, PessoaRepository>();
builder.Services.AddScoped<ICategoria, CategoriaRepository>();
builder.Services.AddScoped<ITransacao, TransacoesRepository>();

builder.Services.AddScoped<IPessoaApplication, PessoaApplication>();
builder.Services.AddScoped<ICategoriaApplication, CategoriaApplication>();
builder.Services.AddScoped<ITransacaoApplication, TransacaoApplication>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
