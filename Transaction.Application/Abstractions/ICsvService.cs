namespace Transaction.Application.Abstractions;

public interface ICsvService
{
    public IEnumerable<T> ReadCSV<T>(Stream file);
}