using DesafioSeguro.Compartilhado.Comandos;

namespace DesafioSeguro.Seguro.Dominio.Comandos.Proposta;

public sealed record SimularPropostaResultado : ResultadoComandoBase
{
    public required decimal Valor { get; set; }
    public required string Placa { get; set; }
    public required string NomeCliente { get; set; }
}