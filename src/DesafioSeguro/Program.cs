using DesafioSeguro.Compartilhado;
using DesafioSeguro.Compartilhado.Comandos;
using DesafioSeguro.Seguro;
using DesafioSeguro.Seguro.Dominio.Comandos.Proposta;

using Microsoft.AspNetCore.Mvc;

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .RegistrarCompartilhadoDependencias()
    .RegistrarSeguroDependencias(builder.Configuration);

builder.Services.AddOpenApi();

var app = builder.Build();

//Está habilitado para todos os ambientes apenas para testar a aplicação
app.MapScalarApiReference();
app.MapOpenApi();

app.UseHttpsRedirection();


app.MapPost("/seguro/proposta", 
        async (CadastrarPropostaComando comando, 
            [FromServices] IManipulador<CadastrarPropostaComando, CadastrarPropostaResultado> manipulador) =>
        {
            var resultado = await manipulador.ManipularAsync(comando);
            return resultado.Sucesso ? Results.Ok(resultado.Dados) : Results.BadRequest(resultado.Erros);
        })
        .WithName("CadastroProposta")
        .WithSummary("Cadastrar propostas de seguros automativos");

app.Run();
