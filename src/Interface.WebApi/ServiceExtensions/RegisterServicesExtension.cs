using Application.Services;
using Core.Interfaces.Application.Services;
using Core.Interfaces.Infra.Database;
using Infra.Database.MySql.Context;
using Infra.Database.MySql.Repositories;

namespace Interface.WebApi.ServiceExtensions;

public static class RegisterServicesExtension
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IPedidoService, PedidoService>();
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<IPedidoRepository, PedidoRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IClienteRepository, ClienteRepository>();
        return services;
    }
}