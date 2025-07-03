using AwesomeAssertions;

using DesafioSeguro.Seguro.Dominio.Entidades;
using DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro;
using DesafioSeguro.Unidade.Construtores;

using Moq;

namespace DesafioSeguro.Unidade.Seguro.Entidades;

public class PropostaTestes : TestesBase
{
    private readonly PropostaConstrutor propostaConstrutor;
 
    private readonly Mock<ICalculadorSeguro> calculadorSeguro;
    
    public PropostaTestes()
    {
        propostaConstrutor = new PropostaConstrutor();
        calculadorSeguro = new Mock<ICalculadorSeguro>();
    }

    [Fact(DisplayName =
        "Dado um calculador de seguro, construtor deve inicializar a proposta com valor igual ao calculado pelo calculador")]
    private void DadoUmCalculadorDeSeguroConstrutorDeveInicializarAPropostaComValorIgualAoCalculadoPeloCalculador()
    {
        var valorCalculado = _faker.Finance.Amount(min: 1);
        
        calculadorSeguro
            .Setup(x=>x.Calcular(It.IsAny<Proposta>()))
            .Returns(valorCalculado);
        
        var proposta = propostaConstrutor
            .ComCalculadorSeguro(calculadorSeguro.Object)
            .Instanciar();

        proposta
            .ValorDoSeguro
            .Valor
            .Should()
            .Be(valorCalculado);

        calculadorSeguro
            .Verify(x => x.Calcular(proposta), Times.Once);
    }
}