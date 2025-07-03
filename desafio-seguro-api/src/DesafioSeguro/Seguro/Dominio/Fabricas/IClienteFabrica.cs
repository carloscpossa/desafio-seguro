using DesafioSeguro.Seguro.Dominio.Comandos.Proposta;
using DesafioSeguro.Seguro.Dominio.Entidades;

namespace DesafioSeguro.Seguro.Dominio.Fabricas;

public interface IClienteFabrica
{
    Cliente Criar(ClientePropostaComando comando);
}