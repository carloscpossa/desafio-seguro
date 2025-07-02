using DesafioSeguro.Seguro.Entidades;

namespace DesafioSeguro.Seguro.Servicos.CalculoSeguro;

public interface ICalculadorSeguroBase
{
    decimal Calcular(Proposta proposta);
}