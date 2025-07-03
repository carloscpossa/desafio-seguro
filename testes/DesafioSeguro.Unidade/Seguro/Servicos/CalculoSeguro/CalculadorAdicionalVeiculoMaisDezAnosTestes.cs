using AwesomeAssertions;

using DesafioSeguro.Compartilhado.Servicos.DataHota;
using DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro.CalculoAdicionaisRisco.RiscosVeiculo;
using DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro.CalculoBase;
using DesafioSeguro.Unidade.Construtores;

using Moq;
using Moq.AutoMock;

namespace DesafioSeguro.Unidade.Seguro.Servicos.CalculoSeguro;

public class CalculadorAdicionalVeiculoMaisDezAnosTestes : TestesBase
{
    private AutoMocker mocker;

    private CalculadorAdicionalVeiculoMaisDezAnos calculador;
    private Mock<ICalculadorSeguroBase> calculadorSeguroBase;
    private Mock<IDataHora> dataHora;

    private VeiculoConstrutor veiculoConstrutor;
    private PropostaConstrutor propostaConstrutor;
    
    private readonly decimal ValorBaseSeguro;
    
    public CalculadorAdicionalVeiculoMaisDezAnosTestes()
    {
        veiculoConstrutor = new VeiculoConstrutor();
        propostaConstrutor = new PropostaConstrutor();
        
        mocker = new AutoMocker();
        
        calculadorSeguroBase = mocker.GetMock<ICalculadorSeguroBase>();
        dataHora = mocker.GetMock<IDataHora>();
        calculador = mocker.CreateInstance<CalculadorAdicionalVeiculoMaisDezAnos>();
        
        ValorBaseSeguro = _faker.Random.Decimal(min: 1m, max: 1000000);
    }
    
    [Fact(DisplayName = "Dada uma proposta com veículo de idade superior a 10 anos, Calcular deve retornar quinze por cento do valor base do seguro")]
    
    public void DadaUmaPropostaComVeiculoDeIdadeSuperiorADezAnosCalcularDeveRetornarQuinzePorCentoDoValorBaseDoSeguro()
    {
        var veiculo = veiculoConstrutor
            .Instanciar();

        dataHora
            .Setup(x => x.DataAtual)
            .Returns(new DateOnly(veiculo.AnoFabricacao + 11, 1, 1));
        
        var proposta = propostaConstrutor
            .ComVeiculo(veiculo)
            .Instanciar();
        
        calculadorSeguroBase
            .Setup(x => x.Calcular(proposta))
            .Returns(ValorBaseSeguro);
        
        var valorCalculado = calculador.Calcular(proposta);

        var valorEsperado = decimal.Round(ValorBaseSeguro * 0.15m, 2, MidpointRounding.AwayFromZero);

        valorCalculado
            .Should()
            .Be(valorEsperado);
    }

    [Fact(DisplayName = "Dada uma proposta com veículo de idade igual a 10 anos, Calcular deve retornar zero")]
    public void DadaUmaPropostaComVeiculoDeIdadeIgualADezAnosCalcularDeveRetornarZero()
    {
        var veiculo = veiculoConstrutor
            .ComValorDeTabela(100_000m)
            .Instanciar();

        dataHora
            .Setup(x => x.DataAtual)
            .Returns(new DateOnly(veiculo.AnoFabricacao + 10, 1, 1));
        
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
    
    [Fact(DisplayName = "Dada uma proposta com veículo de idade inferior a 10 anos, Calcular deve retornar zero")]
    public void DadaUmaPropostaComVeiculoDeIdadeInferiorADezAnosCalcularDeveRetornarZero()
    {
        var veiculo = veiculoConstrutor
            .Instanciar();
        
        dataHora
            .Setup(x => x.DataAtual)
            .Returns(new DateOnly(veiculo.AnoFabricacao + 9, 1, 1));

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