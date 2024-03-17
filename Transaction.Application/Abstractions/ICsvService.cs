namespace Transaction.Application.Abstractions;

public interface ICsvService
{
    public IEnumerable<T> ReadCsv<T>(Stream file);
}