using DesafioSeguro.Compartilhado;

namespace DesafioSeguro.Seguro.Dominio.Entidades;

public class Apolice : Entidade
{
    public Apolice(Proposta proposta, DateOnly dataEmissao)
    {
        IdProposta = proposta.Id;
        Cliente = proposta.Cliente;
        Veiculo = proposta.Veiculo;
        Emissao = dataEmissao;
        Vigencia = new Periodo(Emissao, Emissao.AddYears(1));
        ValorFinal = proposta.ValorDoSeguro;
    }
    
    public Guid IdProposta { get; private set; }
    public Cliente Cliente { get; private set; }
    public Veiculo Veiculo { get; private set; }
    public DateOnly Emissao { get; private set; }
    public Periodo Vigencia { get; private set; }
    public ValorMonetario ValorFinal { get; private set; }
}