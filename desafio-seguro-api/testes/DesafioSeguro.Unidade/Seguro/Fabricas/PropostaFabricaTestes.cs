using AwesomeAssertions;

using DesafioSeguro.Seguro.Dominio.Comandos.Proposta;
using DesafioSeguro.Seguro.Dominio.Entidades;
using DesafioSeguro.Seguro.Dominio.Fabricas;
using DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro;
using DesafioSeguro.Unidade.Construtores;

using Moq;
using Moq.AutoMock;

namespace DesafioSeguro.Unidade.Seguro.Fabricas;

public class PropostaFabricaTestes : TestesBase
{
    private AutoMocker mocker;

    private ClienteConstrutor clienteConstrutor;
    private VeiculoConstrutor veiculoConstrutor;

    private Mock<IClienteFabrica> clienteFabrica;
    private Mock<IVeiculoFabrica> veiculoFabrica;
    private Mock<ICalculadorSeguro> calculadorSeguro;
    private PropostaFabrica propostaFabrica;

    public PropostaFabricaTestes()
    {
        mocker = new AutoMocker();

        clienteFabrica = mocker.GetMock<IClienteFabrica>();
        veiculoFabrica = mocker.GetMock<IVeiculoFabrica>();
        calculadorSeguro = mocker.GetMock<ICalculadorSeguro>();
        propostaFabrica = mocker.CreateInstance<PropostaFabrica>();

        clienteConstrutor = new ClienteConstrutor();
        veiculoConstrutor = new VeiculoConstrutor();
    }

    [Fact(DisplayName = "Dado um comando para cadastrar proposta, Criar deve retornar uma proposta")]
    public void DadoUmCadastrarPropostaComandoCriarDeveRetornarUmaProposta()
    {
        var valorSeguroCalculado = _faker.Random.Decimal(min: 1, max: 100000);

        calculadorSeguro
            .Setup(x => x.Calcular(It.IsAny<Proposta>()))
            .Returns(valorSeguroCalculado);

        var comando = new CadastrarPropostaComando
        {
            Cliente = new ClientePropostaComando(_faker.Person.FullName, _faker.Date.PastDateOnly()),
            Veiculo = new VeiculoPropostaComando(_faker.Random.AlphaNumeric(7), _faker.Random.Decimal(min: 1),
                _faker.Random.Int(min: 1950, max: DateTime.Today.Year))
        };

        var veiculo = veiculoConstrutor.Instanciar();
        var cliente = clienteConstrutor.Instanciar();

        veiculoFabrica
            .Setup((x => x.Criar(comando.Veiculo)))
            .Returns(veiculo);

        clienteFabrica
            .Setup(x => x.Criar(comando.Cliente))
            .Returns(cliente);

        var proposta = propostaFabrica.Criar(comando);

        var propostaEsperada = new
        {
            Client = cliente, Veiculo = veiculo, ValorDoSeguro = new { Valor = valorSeguroCalculado }
        };

        proposta
            .Should()
            .BeEquivalentTo(propostaEsperada, config => config.ExcludingMissingMembers());
    }
}