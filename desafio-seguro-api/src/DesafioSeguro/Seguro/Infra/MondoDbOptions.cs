namespace DesafioSeguro.Seguro.Infra;

public class MondoDbOptions
{
    public const string MongoDb = "MongoDb";

    public string ConnectionString { get; set; }
    public string BancoDeDados { get; set; }
}