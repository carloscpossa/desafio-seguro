using DesafioSeguro.Compartilhado;

namespace DesafioSeguro.Seguro.Entidades;

public class Cliente : Entidade
{
    public Cliente(Nome nome, DateOnly dataDeNascimento)
    {
        Nome = nome;
        DataDeNascimento = dataDeNascimento;
    }

    public Nome Nome { get; private set; }
    public DateOnly DataDeNascimento { get; private set; }
}