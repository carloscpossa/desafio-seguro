using DesafioSeguro.Seguro.Dominio.Entidades;
using DesafioSeguro.Seguro.Dominio.Repositorios;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

namespace DesafioSeguro.Seguro.Infra.Repositorios;

public sealed class ApoliceRepositorio : IApoliceRepositorio, IDisposable
{
    private const string NomeDaColecao = "apolices";
    private readonly IMongoClient _client;
    private readonly IMongoCollection<Apolice> colecao;
    
    public ApoliceRepositorio(IOptions<MondoDbOptions> options)
    {
        var mongoOptions = options.Value;
        
        _client = new MongoClient(mongoOptions.ConnectionString);
        var bancoDados = _client.GetDatabase(mongoOptions.BancoDeDados);
        colecao = bancoDados.GetCollection<Apolice>(NomeDaColecao);
    }
    
    public async Task AdicionarAsync(Apolice apolice)
    {
        await colecao.InsertOneAsync(apolice);
    }

    public void Dispose()
    {
        _client.Dispose();
    }
}