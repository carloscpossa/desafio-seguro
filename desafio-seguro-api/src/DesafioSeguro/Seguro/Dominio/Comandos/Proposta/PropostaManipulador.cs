using DesafioSeguro.Compartilhado;
using DesafioSeguro.Compartilhado.Comandos;
using DesafioSeguro.Seguro.Dominio.Fabricas;
using DesafioSeguro.Seguro.Dominio.Repositorios;

namespace DesafioSeguro.Seguro.Dominio.Comandos.Proposta;

public sealed class PropostaManipulador(IPropostaFabrica propostaFabrica, IPropostaRepositorio repositorio)
    : IManipulador<CadastrarPropostaComando, CadastrarPropostaResultado>
{

    public async Task<Resultado<CadastrarPropostaResultado>> ManipularAsync(CadastrarPropostaComando comando)
    {
        var proposta = propostaFabrica.Criar(comando);
        await repositorio.AdicionarAsync(proposta);
        var dadosRetorno = new CadastrarPropostaResultado(proposta.Id);
        return Resultado<CadastrarPropostaResultado>.ComSucesso(dadosRetorno);
    }
}