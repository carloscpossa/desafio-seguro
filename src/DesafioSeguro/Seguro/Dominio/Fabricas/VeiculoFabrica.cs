using DesafioSeguro.Compartilhado;
using DesafioSeguro.Seguro.Dominio.Comandos.Proposta;
using DesafioSeguro.Seguro.Dominio.Entidades;

namespace DesafioSeguro.Seguro.Dominio.Fabricas;

public sealed class VeiculoFabrica : IVeiculoFabrica
{
    public Veiculo Criar(VeiculoPropostaComando comando)
    {
        var valor = new ValorMonetario(comando.ValorDeTabela);
        return new Veiculo(valor, comando.AnoDeFabricacao);
    }
}