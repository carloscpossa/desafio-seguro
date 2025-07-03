using DesafioSeguro.Compartilhado.Comandos;
using DesafioSeguro.Seguro.Dominio.Comandos.Apolice;

using Microsoft.AspNetCore.Mvc;

namespace DesafioSeguro.Seguro.WebApis;

public static class ApoliceWebApi
{
    public static WebApplication UseApoliceSeguroApis(this WebApplication app)
    {
        app.MapPost("/seguro/apolice", 
                async (EmitirApolicePorPropostaComando comando, 
                    [FromServices] IManipulador<EmitirApolicePorPropostaComando, EmitirApoliceResultado> manipulador) =>
                {
                    var resultado = await manipulador.ManipularAsync(comando);
                    return resultado.Sucesso ? Results.Created("", resultado.Dados) : Results.BadRequest(resultado.Erros);
                })
            .WithTags("Apólice de Seguro")
            .WithSummary("Emitir Apólice")
            .WithDescription("Emitir apólice de seguros automotivos por proposta");
        
        return app;
    }
}