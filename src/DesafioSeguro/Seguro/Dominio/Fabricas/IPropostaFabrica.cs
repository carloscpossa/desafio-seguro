using DesafioSeguro.Seguro.Dominio.Comandos.Proposta;
using DesafioSeguro.Seguro.Dominio.Entidades;

namespace DesafioSeguro.Seguro.Dominio.Fabricas;

public interface IPropostaFabrica
{
    Proposta Criar(CadastrarPropostaComando comando);
}