using DesafioSeguro.Compartilhado;
using DesafioSeguro.Seguro.Dominio.Entidades;
using DesafioSeguro.Seguro.Dominio.ObjetosDeValor;

namespace DesafioSeguro.Unidade.Construtores;

internal sealed class VeiculoConstrutor : ConstrutorBase<VeiculoConstrutor, Veiculo>
{
    private decimal valorDeTabela = 0;
    private int anoFabricacao = 0;
    private string placa = string.Empty;

    public VeiculoConstrutor()
    {
        Redefinir();
    }
    
    public override VeiculoConstrutor Redefinir()
    {
        valorDeTabela = _faker.Finance.Amount(min: 1, max: 10000000, decimals: 2);
        anoFabricacao = _faker.Random.Int(1950, DateTime.Now.Year);
        placa = _faker.Vehicle.Vin();

        return this;
    }

    public VeiculoConstrutor ComValorDeTabela(decimal valor)
    {
        valorDeTabela = valor;
        return this;
    }

    public VeiculoConstrutor ComAnoFabricacao(int ano)
    {
        anoFabricacao = ano;
        return this;
    }

    public VeiculoConstrutor ComPlaca(string placa)
    {
        this.placa = placa;
        return this;
    }
    
    public override Veiculo Instanciar()
    {
        return new Veiculo(new Placa(placa), new ValorMonetario(valorDeTabela), anoFabricacao);
    }
}