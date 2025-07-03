namespace DesafioSeguro.Compartilhado.Comandos;

public interface IManipulador<in TComando, TResultadoComando>
    where TComando : ComandoBase
    where TResultadoComando: ResultadoComandoBase
{
    Task<Resultado<TResultadoComando>> ManipularAsync(TComando comando);    
}