using DesafioSeguro.Compartilhado.Comandos;

namespace DesafioSeguro.Seguro.Dominio.Comandos.Proposta;

public sealed record CadastrarPropostaResultado(Guid IdProposta) : ResultadoComandoBase;
