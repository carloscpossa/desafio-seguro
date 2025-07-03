using DesafioSeguro.Compartilhado;
using DesafioSeguro.Seguro.Dominio.Entidades;

namespace DesafioSeguro.Unidade.Construtores;

internal sealed class ClienteConstrutor : ConstrutorBase<ClienteConstrutor, Cliente>
{
    private string nome = string.Empty;
    private DateTime dataDeNascimento;

    public ClienteConstrutor()
    {
        Redefinir();
    }
    
    public override ClienteConstrutor Redefinir()
    {
        nome = _faker.Person.FullName;
        dataDeNascimento = _faker.Date.Between(new  DateTime(1905, 01, 01), DateTime.Now);

        return this;
    }

    public ClienteConstrutor ComNome(string nome)
    {
        this.nome = nome;
        return this;
    }

    public ClienteConstrutor ComDataDeNascimento(DateTime dataNascimento)
    {
        this.dataDeNascimento = dataNascimento;
        return this;
    }

    public override Cliente Instanciar()
    {
        return new Cliente(new Nome(nome), DateOnly.FromDateTime(dataDeNascimento));
    }
}