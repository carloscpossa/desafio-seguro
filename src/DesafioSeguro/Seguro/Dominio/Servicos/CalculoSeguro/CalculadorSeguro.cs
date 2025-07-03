using DesafioSeguro.Seguro.Dominio.Entidades;
using DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro.CalculoAdicionaisRisco;
using DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro.CalculoBase;

namespace DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro;

public sealed class CalculadorSeguro(
    ICalculadorSeguroBase calculadorSeguroBase,
    IEnumerable<ICalculadorValorAdicional> calculadoresValorAdicional) : ICalculadorSeguro
{
    public decimal Calcular(Proposta proposta)
    {
        return calculadorSeguroBase.Calcular(proposta) + calculadoresValorAdicional.Sum(x => x.Calcular(proposta));
    }
}