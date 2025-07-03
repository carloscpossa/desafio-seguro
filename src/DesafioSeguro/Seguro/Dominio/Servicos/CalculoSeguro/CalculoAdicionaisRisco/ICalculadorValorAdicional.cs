using DesafioSeguro.Seguro.Dominio.Entidades;

namespace DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro.CalculoAdicionaisRisco;

public interface ICalculadorValorAdicional
{
    decimal Calcular(Proposta proposta);
}