namespace DesafioSeguro.Compartilhado;

public record ValorMonetario
{
    public ValorMonetario(decimal valor)
    {
        Valor = valor;
        if (Valor < 0)
            Valor = 0;
    }
    public decimal Valor { get; private set; }
}