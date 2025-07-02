using AwesomeAssertions;

using DesafioSeguro.Seguro.Servicos.CalculoSeguro;
using DesafioSeguro.Unidade.Construtores;

using Moq;
using Moq.AutoMock;

namespace DesafioSeguro.Unidade.Seguro.Servicos.CalculoSeguro;

public class CalculadorAdicionalVeiculoAcimaDeCemMilTestes : TestesBase
{
    private AutoMocker mocker;

    private CalculadorAdicionalVeiculoAcimaDeCemMil calculador;
    private Mock<ICalculadorSeguroBase> calculadorSeguroBase;

    private VeiculoConstrutor veiculoConstrutor;
    private PropostaConstrutor propostaConstrutor;
    
    private readonly decimal ValorBaseSeguro;
    
    public CalculadorAdicionalVeiculoAcimaDeCemMilTestes()
    {
        veiculoConstrutor = new VeiculoConstrutor();
        propostaConstrutor = new PropostaConstrutor();
        
        mocker = new AutoMocker();
        
        calculadorSeguroBase = mocker.GetMock<ICalculadorSeguroBase>();
        calculador = mocker.CreateInstance<CalculadorAdicionalVeiculoAcimaDeCemMil>();
        
        ValorBaseSeguro = _faker.Random.Decimal(min: 1m, max: 1000000);
    }
    
    [Fact(DisplayName = "Dada uma proposta com veículo de valor de tabela acima de cem mil, Calcular deve retornar dez por cento do valor base do seguro")]
    
    public void DadaUmaPropostaDeVeiculoComValorAcimaDeCemMilCalcularDeveRetornarDezPorCentoDoValorBaseDoSeguro()
    {
        var valorDeTabela = _faker.Finance.Amount(min: 100001, max: 1000000000);
        var veiculo = veiculoConstrutor
            .ComValorDeTabela(valorDeTabela)
            .Instanciar();

        var proposta = propostaConstrutor
            .ComVeiculo(veiculo)
            .Instanciar();

        calculadorSeguroBase
            .Setup(x => x.Calcular(proposta))
            .Returns(ValorBaseSeguro);
        
        var valorCalculado = calculador.Calcular(proposta);

        var valorEsperado = decimal.Round(ValorBaseSeguro * 0.1m, 2, MidpointRounding.AwayFromZero);

        valorCalculado
            .Should()
            .Be(valorEsperado);
    }

    [Fact(DisplayName = "Dada uma proposta com veículo de valor de tabela de cem mil, Calcular deve retornar zero")]
    public void DadaUmaPropostaDeVeiculoComValorDeCemMilCalcularDeveRetornarZero()
    {
        var veiculo = veiculoConstrutor
            .ComValorDeTabela(100_000m)
            .Instanciar();

        var proposta = propostaConstrutor
            .ComVeiculo(veiculo)
            .Instanciar();
        
        calculadorSeguroBase
            .Setup(x => x.Calcular(proposta))
            .Returns(ValorBaseSeguro);
        
        var valorCalculado = calculador.Calcular(proposta);

        valorCalculado
            .Should()
            .Be(0);
    }
    
    [Fact(DisplayName = "Dada uma proposta com veículo de valor de tabela abaixo de cem mil, Calcular deve retornar zero")]
    public void DadaUmaPropostaDeVeiculoComValorAbaixoDeCemMilCalcularDeveRetornarZero()
    {
        var veiculo = veiculoConstrutor
            .ComValorDeTabela(_faker.Random.Decimal(min: 1m, max: 99999m))
            .Instanciar();

        var proposta = propostaConstrutor
            .ComVeiculo(veiculo)
            .Instanciar();
        
        calculadorSeguroBase
            .Setup(x => x.Calcular(proposta))
            .Returns(ValorBaseSeguro);
        
        var valorCalculado = calculador.Calcular(proposta);

        valorCalculado
            .Should()
            .Be(0);
    }
}