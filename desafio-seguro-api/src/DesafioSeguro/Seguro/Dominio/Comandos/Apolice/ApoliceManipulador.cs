using DesafioSeguro.Compartilhado;
using DesafioSeguro.Compartilhado.Comandos;
using DesafioSeguro.Seguro.Dominio.Fabricas;
using DesafioSeguro.Seguro.Dominio.Repositorios;

namespace DesafioSeguro.Seguro.Dominio.Comandos.Apolice;

public sealed class ApoliceManipulador : IManipulador<EmitirApolicePorPropostaComando, EmitirApoliceResultado>
{
    private readonly IPropostaRepositorio propostaRepositorio;
    private readonly IApoliceRepositorio apoliceRepositorio;
    private readonly IApoliceFabrica apoliceFabrica;
    
    public ApoliceManipulador(IPropostaRepositorio propostaRepositorio, IApoliceRepositorio apoliceRepositorio, IApoliceFabrica apoliceFabrica)
    {
        this.propostaRepositorio = propostaRepositorio;
        this.apoliceRepositorio = apoliceRepositorio;
        this.apoliceFabrica = apoliceFabrica;
    }
    
    public async Task<Resultado<EmitirApoliceResultado>> ManipularAsync(EmitirApolicePorPropostaComando comando)
    {
        var proposta = await propostaRepositorio.ObterAsync(comando.IdProposta);
        if (proposta is null)
            return Resultado<EmitirApoliceResultado>.ComFalha("Não foi possível emitir a apólice. Proposta de Seguro não econtrada");
        
        var apolice = apoliceFabrica.Criar(proposta);
        await apoliceRepositorio.AdicionarAsync(apolice);
        
        return Resultado<EmitirApoliceResultado>.ComSucesso(new EmitirApoliceResultado
        {
            IdApolice = apolice.Id,
            Vigencia = apolice.Vigencia,
            NomeCliente = apolice.Cliente.Nome.Valor,
            Placa = apolice.Veiculo.Placa.Valor,
            Valor = apolice.ValorFinal.Valor
        });
    }
}