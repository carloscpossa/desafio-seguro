using DesafioSeguro.Seguro.Dominio.Entidades;
using DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro.CalculoBase;

namespace DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro.CalculoAdicionaisRisco.RiscosVeiculo;

public sealed class CalculadorAdicionalVeiculoAcimaDeCemMil(ICalculadorSeguroBase calculadorSeguroBase) : ICalculadorValorAdicional
{
    public decimal Calcular(Proposta proposta)
    {
        if (proposta.Veiculo.ValorDeTabela.Valor > 100000m)
            return decimal.Round(calculadorSeguroBase.Calcular(proposta) * 0.1m, 2,  MidpointRounding.AwayFromZero);

        return 0;
    }
}