using DesafioSeguro.Compartilhado.Servicos.CalculadorIdade;
using DesafioSeguro.Compartilhado.Servicos.DataHota;

namespace DesafioSeguro.Compartilhado;

public static class Dependencias
{
    public static IServiceCollection RegistrarCompartilhadoDependencias(this IServiceCollection services)
    {
        services.AddScoped<IDataHora, DataHora>();
        services.AddScoped<ICalculadorIdade, CalculadorIdade>();
        
        return services;
    }
}