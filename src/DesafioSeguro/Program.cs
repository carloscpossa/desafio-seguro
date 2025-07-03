using DesafioSeguro.Compartilhado;
using DesafioSeguro.Seguro;
using DesafioSeguro.Seguro.WebApis;

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

app.UsePropostaSeguroApis()
    .UseApoliceSeguroApis();    

app.Run();
