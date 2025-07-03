using DesafioSeguro.Compartilhado;
using DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro;

namespace DesafioSeguro.Seguro.Dominio.Entidades;

public class Proposta : Entidade
{
    public Proposta(Veiculo veiculo, Cliente cliente, ICalculadorSeguro calculadorSeguro)
    {
        Veiculo = veiculo;
        Cliente = cliente;

        var valorSeguro = calculadorSeguro.Calcular(this);
        ValorDoSeguro = new ValorMonetario(valorSeguro);
    }

    public Veiculo Veiculo { get; private set; }
    public Cliente Cliente { get; private set; }
    public ValorMonetario ValorDoSeguro { get; private set; }
}