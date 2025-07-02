using DesafioSeguro.Compartilhado;

namespace DesafioSeguro.Seguro.Entidades;

public class Veiculo : Entidade
{
    public Veiculo(ValorMonetario valorDeTabela, int anoFabricacao)
    {
        ValorDeTabela = valorDeTabela;
        AnoFabricacao = anoFabricacao;
    }

    public ValorMonetario ValorDeTabela { get; private set; }
    public int AnoFabricacao { get; private set; }
}