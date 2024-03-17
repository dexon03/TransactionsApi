namespace Transaction.Application.Abstractions;

public interface IExcelService
{
    byte[] Export<T>(IEnumerable<T> data);
}