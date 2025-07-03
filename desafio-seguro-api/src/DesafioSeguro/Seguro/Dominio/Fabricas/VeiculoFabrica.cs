using DesafioSeguro.Compartilhado;
using DesafioSeguro.Seguro.Dominio.Comandos.Proposta;
using DesafioSeguro.Seguro.Dominio.Entidades;
using DesafioSeguro.Seguro.Dominio.ObjetosDeValor;

namespace DesafioSeguro.Seguro.Dominio.Fabricas;

public sealed class VeiculoFabrica : IVeiculoFabrica
{
    public Veiculo Criar(VeiculoPropostaComando comando)
    {
        var placa = new Placa(comando.placa);
        var valor = new ValorMonetario(comando.ValorDeTabela);
        return new Veiculo(placa, valor, comando.AnoDeFabricacao);
    }
}