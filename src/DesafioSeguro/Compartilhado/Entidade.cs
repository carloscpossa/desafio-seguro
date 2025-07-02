namespace DesafioSeguro.Compartilhado;

public abstract class Entidade
{
    protected Entidade()
    {
        Id = Guid.CreateVersion7();
    }
    public Guid Id { get; private set; }
}