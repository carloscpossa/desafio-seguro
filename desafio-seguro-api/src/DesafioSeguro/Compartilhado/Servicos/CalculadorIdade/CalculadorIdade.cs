using DesafioSeguro.Compartilhado.Servicos.DataHota;

namespace DesafioSeguro.Compartilhado.Servicos.CalculadorIdade;

public sealed class CalculadorIdade (IDataHora dataHora) : ICalculadorIdade
{
    public int CalcularIdadeEmAnos(DateOnly dataDeNascimento)
    {
        var idade = dataHora.DataAtual.Year - dataDeNascimento.Year;
        if (dataHora.DataAtual.DayOfYear < dataDeNascimento.DayOfYear)
            idade--;
        
        return idade;
    }
}