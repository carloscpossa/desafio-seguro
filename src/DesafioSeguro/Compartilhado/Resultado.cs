namespace DesafioSeguro.Compartilhado;

public sealed record Resultado<TDados>
    where TDados : class
{
    public IReadOnlyCollection<Notificacao> Erros { get; private init; }
    public bool Sucesso { get; private init; }
    public bool Falha => Sucesso == false;
    public TDados? Dados { get; private init; }
    
    private Resultado(TDados? dados)
    {
        Erros = new List<Notificacao>();
        Dados = dados;
        Sucesso = true;
    }

    private Resultado(IEnumerable<Notificacao> erros)
    {
        Dados = null;
        Erros = erros.ToList();
    }
    
    public static Resultado<TDados> ComSucesso(TDados dados)
    {
        return new Resultado<TDados>(dados);
    }
    
    public static Resultado<TDados> ComFalha(IEnumerable<Notificacao> erros)
    {
        return new Resultado<TDados>(erros);
    }
    
    public static Resultado<TDados> ComFalha(string erro)
    {
        return new Resultado<TDados>([new Notificacao(string.Empty, erro)]);
    }
    
    public bool Equals(Resultado<TDados>? other)
    {
        if  (other is null) return false;
        
        if (ReferenceEquals(this, other)) return true;
        
        if (Dados is null)
            return Sucesso == other.Sucesso
                   && other.Dados is null
                   && Erros.SequenceEqual(other.Erros);
            
            
        return Sucesso == other.Sucesso
               && Dados.Equals(other.Dados)
               && Erros.SequenceEqual(other.Erros);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Erros, Sucesso, Dados);
    }
}