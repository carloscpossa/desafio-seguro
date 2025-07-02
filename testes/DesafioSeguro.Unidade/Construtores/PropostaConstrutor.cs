using DesafioSeguro.Compartilhado;
using DesafioSeguro.Seguro.Entidades;

namespace DesafioSeguro.Unidade.Construtores;

internal sealed class PropostaConstrutor : ConstrutorBase<PropostaConstrutor, Proposta>
{
    private readonly ClienteConstrutor clienteConstrutor = new();
    private readonly VeiculoConstrutor veiculoConstrutor = new();

    private Cliente cliente;
    private Veiculo veiculo;
    private ValorMonetario valorDoSeguro = new(0);

    public PropostaConstrutor()
    {
        Redefinir();
    }

    public PropostaConstrutor ComVeiculo(Veiculo veiculo)
    {
        this.veiculo = veiculo;
        return this;
    }
    
    public override PropostaConstrutor Redefinir()
    {
        cliente = clienteConstrutor
            .Redefinir()
            .Instanciar();

        veiculo = veiculoConstrutor
            .Redefinir()
            .Instanciar();

        valorDoSeguro = new ValorMonetario(_faker.Random.Decimal(min: 1));
        
        return this;
    }

    public override Proposta Instanciar()
    {
        return new Proposta(veiculo, cliente, valorDoSeguro);
    }
}