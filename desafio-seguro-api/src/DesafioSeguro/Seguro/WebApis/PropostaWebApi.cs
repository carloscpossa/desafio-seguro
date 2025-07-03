using DesafioSeguro.Compartilhado.Comandos;
using DesafioSeguro.Seguro.Dominio.Comandos.Proposta;

using Microsoft.AspNetCore.Mvc;

namespace DesafioSeguro.Seguro.WebApis;

public static class PropostaWebApi
{
    private const string Tag = "Proposta de Seguro"; 
    public static WebApplication UsePropostaSeguroApis(this WebApplication app)
    {
        app.MapPost("/seguro/proposta",
                async (CadastrarPropostaComando comando,
                    [FromServices] IManipulador<CadastrarPropostaComando, CadastrarPropostaResultado> manipulador) =>
                {
                    var resultado = await manipulador.ManipularAsync(comando);
                    return resultado.Sucesso ? Results.Created("", resultado.Dados) : Results.BadRequest(resultado.Erros);
                })
            .WithTags(Tag)
            .WithSummary("Cadastrar Proposta")
            .WithDescription("Cadastrar propostas de seguros automotivos");

        return app;
    }
    
}