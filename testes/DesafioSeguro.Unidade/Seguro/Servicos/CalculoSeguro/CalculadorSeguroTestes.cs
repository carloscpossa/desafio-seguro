using AwesomeAssertions;

using DesafioSeguro.Seguro.Servicos.CalculoSeguro;
using DesafioSeguro.Unidade.Construtores;

using Moq;

namespace DesafioSeguro.Unidade.Seguro.Servicos.CalculoSeguro;

public class CalculadorSeguroTestes : TestesBase
{
    private CalculadorSeguro calculador;
    private Mock<ICalculadorSeguroBase> calculadorSeguroBase;
    private Mock<ICalculadorValorAdicional> calculadorValorAdicionalVeiculo;
    private Mock<ICalculadorValorAdicional> calculadorValorAdicionalCliente;
    
    private PropostaConstrutor propostaConstrutor;
    
    private readonly decimal ValorBaseSeguro;

    public CalculadorSeguroTestes()
    {
        propostaConstrutor = new PropostaConstrutor();
        
        calculadorSeguroBase = new Mock<ICalculadorSeguroBase>();
        calculadorValorAdicionalCliente = new Mock<ICalculadorValorAdicional>();
        calculadorValorAdicionalVeiculo = new Mock<ICalculadorValorAdicional>();
        
        calculador = new CalculadorSeguro
        (calculadorSeguroBase.Object,
            [calculadorValorAdicionalCliente.Object, calculadorValorAdicionalVeiculo.Object]);
    }
    
    [Fact(DisplayName = "Dada uma proposta de seguro, Calcular deve retornar a soma do valor base do seguro com os valores adicionais")]
    public void DadaUmPropostaDeSeguroCalcularDeveRetornarASomaDoValorBaseDoSeguroComOsValoresAdicionais()
    {
        var proposta = propostaConstrutor.Instanciar();
        
        var valorSeguroBase = _faker.Finance.Amount(min: 1, max: 99999.99m);
        var valorAdicionalCliente = _faker.Finance.Amount(min: 1, max: 99999.99m);
        var valorAdicionalVeiculo  = _faker.Finance.Amount(min: 1, max: 99999.99m);
        
        calculadorSeguroBase
            .Setup(x=>x.Calcular(proposta))
            .Returns(valorSeguroBase);
        
        calculadorValorAdicionalCliente
            .Setup(x=>x.Calcular(proposta))
            .Returns(valorAdicionalCliente);
        
        calculadorValorAdicionalVeiculo
            .Setup(x=>x.Calcular(proposta))
            .Returns(valorAdicionalVeiculo);
        
        var valorEsperado = valorSeguroBase + valorAdicionalCliente + valorAdicionalVeiculo;
        
        var valorCalculado = calculador.Calcular(proposta);
        
        valorCalculado
            .Should()
            .Be(valorEsperado);
    }
}