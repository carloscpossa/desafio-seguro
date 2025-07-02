using DesafioSeguro.Seguro.Entidades;

namespace DesafioSeguro.Seguro.Servicos.CalculoSeguro;

public interface ICalculadorSeguro
{
    decimal Calcular(Proposta proposta);
}