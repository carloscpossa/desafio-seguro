using DesafioSeguro.Compartilhado.Servicos.DataHota;
using DesafioSeguro.Seguro.Dominio.Entidades;

namespace DesafioSeguro.Seguro.Dominio.Fabricas;

public sealed class ApoliceFabrica(IDataHora dataHora) : IApoliceFabrica
{
    public Apolice Criar(Proposta proposta)
    {
        return new Apolice(proposta, dataHora.DataAtual);
    }
}