using DesafioSeguro.Seguro.Dominio.Entidades;

namespace DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro.CalculoBase;

public sealed class CalculadorSeguroBase : ICalculadorSeguroBase
{
    public decimal Calcular(Proposta proposta)
    {
        return decimal.Round(proposta.Veiculo.ValorDeTabela.Valor * 0.06m, 2,MidpointRounding.AwayFromZero);
    }
}