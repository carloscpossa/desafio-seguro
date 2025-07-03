using DesafioSeguro.Compartilhado.Servicos.DataHota;
using DesafioSeguro.Seguro.Dominio.Entidades;
using DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro.CalculoBase;

namespace DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro.CalculoAdicionaisRisco.RiscosVeiculo;

public sealed class CalculadorAdicionalVeiculoMaisDezAnos
    (ICalculadorSeguroBase calculadorSeguroBase, IDataHora dataHora) : ICalculadorValorAdicional
{
    public decimal Calcular(Proposta proposta)
    {
        if (proposta.Veiculo.AnoFabricacao < (dataHora.DataAtual.Year - 10))
            return decimal.Round(calculadorSeguroBase.Calcular(proposta) * 0.15m, 2, MidpointRounding.AwayFromZero);
        
        return 0;
    }
}