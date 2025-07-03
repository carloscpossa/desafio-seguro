using DesafioSeguro.Compartilhado;
using DesafioSeguro.Seguro.Dominio.Entidades;
using DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro;

namespace DesafioSeguro.Unidade.Construtores;

internal sealed class PropostaConstrutor : ConstrutorBase<PropostaConstrutor, Proposta>
{
    private readonly ClienteConstrutor clienteConstrutor = new();
    private readonly VeiculoConstrutor veiculoConstrutor = new();

    private Cliente cliente;
    private Veiculo veiculo;
    private ICalculadorSeguro calculadorSeguro;
    
    
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

        calculadorSeguro = new CalculadorSeguroFalso();
        
        return this;
    }

    public override Proposta Instanciar()
    {
        return new Proposta(veiculo, cliente, calculadorSeguro);
    }
}

internal class CalculadorSeguroFalso : ICalculadorSeguro
{
    public decimal Calcular(Proposta proposta)
    {
        return decimal.Round(proposta.Veiculo.ValorDeTabela.Valor * 0.06m, 2, MidpointRounding.AwayFromZero);
    }
}