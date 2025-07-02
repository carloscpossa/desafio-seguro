using DesafioSeguro.Compartilhado;

namespace DesafioSeguro.Seguro.Entidades;

public class Proposta : Entidade
{
    public Proposta(Veiculo veiculo, Cliente cliente, ValorMonetario valorDoSeguro)
    {
        Veiculo = veiculo;
        Cliente = cliente;
        ValorDoSeguro = valorDoSeguro;
    }

    public Veiculo Veiculo { get; private set; }
    public Cliente Cliente { get; private set; }
    public ValorMonetario ValorDoSeguro { get; private set; }
}