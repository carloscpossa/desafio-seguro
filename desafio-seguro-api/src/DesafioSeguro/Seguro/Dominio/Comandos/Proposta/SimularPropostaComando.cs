using DesafioSeguro.Compartilhado.Comandos;

namespace DesafioSeguro.Seguro.Dominio.Comandos.Proposta;

public sealed record SimularPropostaComando : ComandoBase
{
    public VeiculoPropostaComando Veiculo { get; set; }
    public ClientePropostaComando Cliente { get; set; }
}