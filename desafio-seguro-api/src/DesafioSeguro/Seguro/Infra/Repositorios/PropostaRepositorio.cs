using DesafioSeguro.Seguro.Dominio.Entidades;
using DesafioSeguro.Seguro.Dominio.Repositorios;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

namespace DesafioSeguro.Seguro.Infra.Repositorios;

public sealed class PropostaRepositorio : IPropostaRepositorio, IDisposable
{
    private const string NomeDaColecao = "propostas";
    private readonly IMongoClient _client;
    private readonly IMongoCollection<Proposta> colecao; 
    
    public PropostaRepositorio(IOptions<MondoDbOptions> options)
    {
        var mongoOptions = options.Value;
        
        _client = new MongoClient(mongoOptions.ConnectionString);
        var bancoDados = _client.GetDatabase(mongoOptions.BancoDeDados);
        colecao = bancoDados.GetCollection<Proposta>(NomeDaColecao);
    }
    
    public async Task AdicionarAsync(Proposta proposta)
    {
        await colecao.InsertOneAsync(proposta);
    }

    public async Task<Proposta?> ObterAsync(Guid id)
    {
        var filter = Builders<Proposta>.Filter.Eq(x => x.Id, id);
        return await (await colecao.FindAsync(filter)).FirstOrDefaultAsync();
    }

    public void Dispose()
    {
        _client.Dispose();
    }
}