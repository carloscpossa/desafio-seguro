using DesafioSeguro.Compartilhado;
using DesafioSeguro.Compartilhado.Comandos;

namespace DesafioSeguro.Seguro.Dominio.Comandos.Apolice;

public sealed record EmitirApoliceResultado : ResultadoComandoBase
{
    public required Guid IdApolice { get; set; }
    public required Periodo Vigencia { get; set; }
    public required decimal Valor { get; set; }
    public required string Placa { get; set; }
    public required string NomeCliente { get; set; }
}