using DesafioSeguro.Compartilhado.Servicos.CalculadorIdade;
using DesafioSeguro.Seguro.Entidades;

namespace DesafioSeguro.Seguro.Servicos.CalculoSeguro;

public class CalculadorAdicionalClienteAcimaSessentaAnos
    (ICalculadorSeguroBase calculadorSeguroBase, ICalculadorIdade calculadorIdade) : ICalculadorValorAdicional
{
    public decimal Calcular(Proposta proposta)
    {
        var idadeDoCliente = calculadorIdade.CalcularIdadeEmAnos(proposta.Cliente.DataDeNascimento);
        if (idadeDoCliente > 60)
            return calculadorSeguroBase.Calcular(proposta) * 0.3m;
        
        return 0;
    }
}