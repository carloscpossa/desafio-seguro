using DesafioSeguro.Compartilhado;
using DesafioSeguro.Seguro.Dominio.Comandos.Proposta;
using DesafioSeguro.Seguro.Dominio.Entidades;

namespace DesafioSeguro.Seguro.Dominio.Fabricas;

public sealed class ClienteFabrica : IClienteFabrica
{
    public Cliente Criar(ClientePropostaComando comando)
    {
        var nome = new Nome(comando.Nome);
        return new Cliente(nome, comando.DataNascimento);
    }
}