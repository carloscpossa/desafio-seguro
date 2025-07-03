using DesafioSeguro.Seguro.Dominio.Entidades;
using DesafioSeguro.Seguro.Dominio.Repositorios;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

namespace DesafioSeguro.Seguro.Infra.Repositorios;

public sealed class PropostaRepositorio : IPropostaRepositorio, IDisposable
{
    private const string NomeDaColecao = "propostas";
    private readonly string nomeDoBancoDeDados;
    private readonly IMongoClient _client;
    
    public PropostaRepositorio(IOptions<MondoDbOptions> options)
    {
        var mongoOptions = options.Value;
        nomeDoBancoDeDados = mongoOptions.BancoDeDados;
        _client = new MongoClient(mongoOptions.ConnectionString);
    }
    
    public async Task AdicionarAsync(Proposta proposta)
    {
        var bancoDados = _client.GetDatabase(nomeDoBancoDeDados);
        var colecao = bancoDados.GetCollection<Proposta>(NomeDaColecao);
        await colecao.InsertOneAsync(proposta);
    }

    public void Dispose()
    {
        _client.Dispose();
    }
}