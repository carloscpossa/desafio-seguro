namespace DesafioSeguro.Compartilhado.Servicos.DataHota;

public sealed class DataHora : IDataHora
{
    public DateOnly DataAtual => DateOnly.FromDateTime(DateTime.Now);
}