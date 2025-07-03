using DesafioSeguro.Seguro.Dominio.Entidades;

namespace DesafioSeguro.Seguro.Dominio.Servicos.CalculoSeguro.CalculoBase;

public interface ICalculadorSeguroBase
{
    decimal Calcular(Proposta proposta);
}