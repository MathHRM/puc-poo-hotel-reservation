public class DatabaseConnectionException : Exception
{
    public DatabaseConnectionException()
        : base("Não foi possível conectar ao banco de dados.") { }

    public DatabaseConnectionException(string message)
        : base(message) { }

    public DatabaseConnectionException(string message, Exception innerException)
        : base(message, innerException) { }
}