using DesafioSeguro.Seguro.Dominio.Entidades;

namespace DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro;

public interface ICalculadorSeguro
{
    decimal Calcular(Proposta proposta);
}