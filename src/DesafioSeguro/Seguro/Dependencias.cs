using DesafioSeguro.Compartilhado.Comandos;
using DesafioSeguro.Seguro.Dominio.Comandos.Apolice;
using DesafioSeguro.Seguro.Dominio.Comandos.Proposta;
using DesafioSeguro.Seguro.Dominio.Fabricas;
using DesafioSeguro.Seguro.Dominio.Repositorios;
using DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro;
using DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro.CalculoAdicionaisRisco;
using DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro.CalculoAdicionaisRisco.RiscosCliente;
using DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro.CalculoAdicionaisRisco.RiscosVeiculo;
using DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro.CalculoBase;
using DesafioSeguro.Seguro.Infra;
using DesafioSeguro.Seguro.Infra.Repositorios;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace DesafioSeguro.Seguro;

public static class Dependencias
{
    public static IServiceCollection RegistrarSeguroDependencias(this IServiceCollection services,
        IConfiguration configuration)
    {
        //Manipuladores (Handlers)
        services.AddScoped<IManipulador<CadastrarPropostaComando, CadastrarPropostaResultado>, PropostaManipulador>();
        services.AddScoped<IManipulador<EmitirApolicePorPropostaComando, EmitirApoliceResultado>, ApoliceManipulador>();
        
        //Fábricas
        services.AddScoped<IClienteFabrica, ClienteFabrica>();
        services.AddScoped<IVeiculoFabrica, VeiculoFabrica>();
        services.AddScoped<IPropostaFabrica, PropostaFabrica>();
        services.AddScoped<IApoliceFabrica, ApoliceFabrica>();
        
        //Servicos
        services.AddScoped<ICalculadorSeguro, CalculadorSeguro>();
        services.AddScoped<ICalculadorSeguroBase, CalculadorSeguroBase>();
        services.AddScoped<ICalculadorValorAdicional, CalculadorAdicionalClienteAbaixoVinteCincoAnos>();
        services.AddScoped<ICalculadorValorAdicional, CalculadorAdicionalClienteAcimaSessentaAnos>();
        services.AddScoped<ICalculadorValorAdicional, CalculadorAdicionalVeiculoAcimaDeCemMil>();
        services.AddScoped<ICalculadorValorAdicional, CalculadorAdicionalVeiculoMaisDezAnos>();
        
        //Repositórios
        services.AddScoped<IPropostaRepositorio, PropostaRepositorio>();
        services.AddScoped<IApoliceRepositorio, ApoliceRepositorio>();
        
        //Options
        services.Configure<MondoDbOptions>(options =>
        {
            configuration.GetSection("MongoDb").Bind(options);
        });
        
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
        
        return services;
    }
}