using DesafioSeguro.Compartilhado;
using DesafioSeguro.Compartilhado.Comandos;
using DesafioSeguro.Seguro.Dominio.Fabricas;

namespace DesafioSeguro.Seguro.Dominio.Comandos.Proposta;

public class SimularPropostaManipulador(IPropostaFabrica propostaFabrica) : IManipulador<SimularPropostaComando, SimularPropostaResultado>
{
    public Task<Resultado<SimularPropostaResultado>> ManipularAsync(SimularPropostaComando comando)
    {
        var proposta = propostaFabrica.Criar(new CadastrarPropostaComando()
        {
            Cliente = comando.Cliente, Veiculo = comando.Veiculo,
        });
        
        return Task.FromResult(Resultado<SimularPropostaResultado>.ComSucesso(new SimularPropostaResultado()
        {
            NomeCliente = proposta.Cliente.Nome.Valor,
            Placa = proposta.Veiculo.Placa.Valor,
            Valor = proposta.ValorDoSeguro.Valor
        }));
    }
}