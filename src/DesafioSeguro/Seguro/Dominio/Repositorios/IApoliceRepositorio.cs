using DesafioSeguro.Seguro.Dominio.Entidades;

namespace DesafioSeguro.Seguro.Dominio.Repositorios;

public interface IApoliceRepositorio
{
    Task AdicionarAsync(Apolice apolice);
}