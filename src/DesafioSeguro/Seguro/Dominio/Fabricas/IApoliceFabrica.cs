using DesafioSeguro.Seguro.Dominio.Entidades;

namespace DesafioSeguro.Seguro.Dominio.Fabricas;

public interface IApoliceFabrica
{
    Apolice Criar(Proposta proposta);
}