using AwesomeAssertions;

using DesafioSeguro.Compartilhado.Servicos.CalculadorIdade;
using DesafioSeguro.Seguro.Dominio.Entidades;
using DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro.CalculoAdicionaisRisco.RiscosCliente;
using DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro.CalculoBase;
using DesafioSeguro.Unidade.Construtores;

using Moq;
using Moq.AutoMock;

namespace DesafioSeguro.Unidade.Seguro.Servicos.CalculoSeguro;

public class CalculadorAdicionalClienteAcimaSessentaAnosTestes : TestesBase
{
    private AutoMocker mocker;

    private CalculadorAdicionalClienteAcimaSessentaAnos calculador;
    private Mock<ICalculadorSeguroBase> calculadorSeguroBase;
    private Mock<ICalculadorIdade> calculadorIdade;
    
    private PropostaConstrutor propostaConstrutor;
    
    private Proposta proposta;
    private readonly decimal ValorBaseSeguro;
    
    public CalculadorAdicionalClienteAcimaSessentaAnosTestes()
    {
        propostaConstrutor = new PropostaConstrutor();
        
        mocker = new AutoMocker();
        
        calculadorSeguroBase = mocker.GetMock<ICalculadorSeguroBase>();
        calculadorIdade = mocker.GetMock<ICalculadorIdade>();
        calculador = mocker.CreateInstance<CalculadorAdicionalClienteAcimaSessentaAnos>();
        
        proposta = propostaConstrutor.Instanciar();
        ValorBaseSeguro = _faker.Random.Decimal(min: 1m);
        
        calculadorSeguroBase
            .Setup(x => x.Calcular(proposta))
            .Returns(ValorBaseSeguro);
    }
    
    [Fact(DisplayName = "Dada uma proposta de cliente com idade superior a 60 anos, Calcular deve retornar trinta por cento do valor base do seguro")]
    
    public void DadaUmaPropostaDeClienteComIdadeSuperiorASessentaAnosCalcularDeveRetornarTrintaPorCentoDoValorBaseDoSeguro()
    {
        var idade = _faker.Random.Int(min: 61);
        calculadorIdade
            .Setup(x => x.CalcularIdadeEmAnos(proposta.Cliente.DataDeNascimento))
            .Returns(idade);
        
        var valorCalculado = calculador.Calcular(proposta);

        var valorEsperado = decimal.Round(ValorBaseSeguro * 0.3m, 2, MidpointRounding.AwayFromZero);

        valorCalculado
            .Should()
            .Be(valorEsperado);
    }

    [Fact(DisplayName = "Dada uma proposta de cliente com idade igual a 60 anos, Calcular deve retornar zero")]
    public void DadaUmaPropostaDeClienteComIdadeIgualASessentaAnosCalcularDeveRetornarZero()
    {
        calculadorIdade
            .Setup(x => x.CalcularIdadeEmAnos(proposta.Cliente.DataDeNascimento))
            .Returns(60);
        
        var valorCalculado = calculador.Calcular(proposta);

        valorCalculado
            .Should()
            .Be(0);
    }
    
    [Fact(DisplayName = "Dada uma proposta de cliente com idade inferior a 60 anos, Calcular deve retornar zero")]
    public void DadaUmaPropostaDeClienteComIdadeInferiorASessentaAnosCalcularDeveRetornarZero()
    {
        var idade = _faker.Random.Int(max: 59);
        
        calculadorIdade
            .Setup(x => x.CalcularIdadeEmAnos(proposta.Cliente.DataDeNascimento))
            .Returns(idade);
        
        var valorCalculado = calculador.Calcular(proposta);

        valorCalculado
            .Should()
            .Be(0);
    }
}