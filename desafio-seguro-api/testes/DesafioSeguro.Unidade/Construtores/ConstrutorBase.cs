using Bogus;

namespace DesafioSeguro.Unidade.Construtores;

internal abstract class ConstrutorBase<TConstrutor, TResultado> where TConstrutor : ConstrutorBase<TConstrutor, TResultado>
{
    protected readonly Faker _faker = new("pt_BR");
    public abstract TConstrutor Redefinir();
    public abstract TResultado Instanciar();
}