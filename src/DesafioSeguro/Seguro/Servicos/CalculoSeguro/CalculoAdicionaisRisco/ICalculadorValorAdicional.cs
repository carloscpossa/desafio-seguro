using DesafioSeguro.Seguro.Entidades;

namespace DesafioSeguro.Seguro.Servicos.CalculoSeguro;

public interface ICalculadorValorAdicional
{
    decimal Calcular(Proposta proposta);
}