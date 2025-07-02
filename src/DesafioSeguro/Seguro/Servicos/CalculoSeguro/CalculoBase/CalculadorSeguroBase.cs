using DesafioSeguro.Seguro.Entidades;

namespace DesafioSeguro.Seguro.Servicos.CalculoSeguro;

public sealed class CalculadorSeguroBase : ICalculadorSeguroBase
{
    public decimal Calcular(Proposta proposta)
    {
        return decimal.Round(proposta.Veiculo.ValorDeTabela.Valor * 0.06m, 2,MidpointRounding.AwayFromZero);
    }
}