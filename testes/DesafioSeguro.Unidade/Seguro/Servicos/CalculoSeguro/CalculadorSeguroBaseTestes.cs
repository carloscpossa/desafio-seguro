using AwesomeAssertions;

using DesafioSeguro.Seguro.Servicos.CalculoSeguro;
using DesafioSeguro.Unidade.Construtores;

namespace DesafioSeguro.Unidade.Seguro.Servicos.CalculoSeguro;

public class CalculadorSeguroBaseTestes : TestesBase
{
    private readonly PropostaConstrutor propostaConstrutor;
    private CalculadorSeguroBase calculador;

    public CalculadorSeguroBaseTestes()
    {
        propostaConstrutor = new PropostaConstrutor();
        calculador = new CalculadorSeguroBase();
    }

    [Fact(DisplayName = "Dada uma proposta de seguro, Calcular deve retornar seis por cento do valor de tabela do veículo")]
    public void DadaUmaPropostaCalcularDeveRetornarSeisPorCentoDoValorDeTabelaDoVeiculo()
    {
        var proposta = propostaConstrutor.Instanciar();
        var valorCalculado = calculador.Calcular(proposta);

        var valorEsperado = decimal.Round(proposta.Veiculo.ValorDeTabela.Valor * 0.06m, 2,MidpointRounding.AwayFromZero);

        valorCalculado
            .Should()
            .Be(valorEsperado);
    }
}