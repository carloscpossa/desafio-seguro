using DesafioSeguro.Compartilhado.Comandos;

namespace DesafioSeguro.Seguro.Dominio.Comandos.Apolice;

public sealed record EmitirApolicePorPropostaComando : ComandoBase
{
    public Guid IdProposta { get; set; }
}