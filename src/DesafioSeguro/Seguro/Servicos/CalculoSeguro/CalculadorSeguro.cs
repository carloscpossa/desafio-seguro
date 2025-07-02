using DesafioSeguro.Seguro.Entidades;

namespace DesafioSeguro.Seguro.Servicos.CalculoSeguro;

public sealed class CalculadorSeguro(
    ICalculadorSeguroBase calculadorSeguroBase,
    IEnumerable<ICalculadorValorAdicional> calculadoresValorAdicional) : ICalculadorSeguro
{
    public decimal Calcular(Proposta proposta)
    {
        return calculadorSeguroBase.Calcular(proposta) + calculadoresValorAdicional.Sum(x => x.Calcular(proposta));
    }
}