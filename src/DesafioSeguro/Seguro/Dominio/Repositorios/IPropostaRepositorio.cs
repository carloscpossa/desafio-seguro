using DesafioSeguro.Seguro.Dominio.Entidades;

namespace DesafioSeguro.Seguro.Dominio.Repositorios;

public interface IPropostaRepositorio
{
    Task AdicionarAsync(Proposta proposta);
    Task<Proposta?> ObterAsync(Guid id);
}