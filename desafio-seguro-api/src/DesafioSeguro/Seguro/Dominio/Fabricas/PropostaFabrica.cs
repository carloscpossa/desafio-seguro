using DesafioSeguro.Seguro.Dominio.Comandos.Proposta;
using DesafioSeguro.Seguro.Dominio.Entidades;
using DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro;

namespace DesafioSeguro.Seguro.Dominio.Fabricas;

public sealed class PropostaFabrica
    (IVeiculoFabrica veiculoFabrica, IClienteFabrica clienteFabrica, ICalculadorSeguro calculadorSeguro) : IPropostaFabrica
{
    public Proposta Criar(CadastrarPropostaComando comando)
    {
        var veiculo = veiculoFabrica.Criar(comando.Veiculo);
        var cliente = clienteFabrica.Criar(comando.Cliente);
        
        return new Proposta(veiculo, cliente, calculadorSeguro);
    }
}