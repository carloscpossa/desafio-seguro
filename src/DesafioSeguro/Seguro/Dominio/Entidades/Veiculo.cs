using DesafioSeguro.Compartilhado;
using DesafioSeguro.Seguro.Dominio.ObjetosDeValor;

namespace DesafioSeguro.Seguro.Dominio.Entidades;

public class Veiculo : Entidade
{
    public Veiculo(Placa placa, ValorMonetario valorDeTabela, int anoFabricacao)
    {
        Placa = placa;
        ValorDeTabela = valorDeTabela;
        AnoFabricacao = anoFabricacao;
    }

    public Placa Placa { get; private set; }
    public ValorMonetario ValorDeTabela { get; private set; }
    public int AnoFabricacao { get; private set; }
}