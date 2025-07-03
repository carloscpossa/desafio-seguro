using DesafioSeguro.Compartilhado;

namespace DesafioSeguro.Seguro.Dominio.Entidades;

public class Apolice : Entidade
{
    public Periodo Vigencia { get; private set; }
    public ValorMonetario ValorFinal { get; private set; }
}