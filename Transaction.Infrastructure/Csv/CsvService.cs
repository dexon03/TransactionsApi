using System.Globalization;
using CsvHelper;
using Transaction.Application.Abstractions;

namespace Transaction.Infrastructure.Csv;

public class CsvService : ICsvService
{
    public IEnumerable<T> ReadCSV<T>(Stream file)
    {
        var reader = new StreamReader(file);
        var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var records = csv.GetRecords<T>();
        return records;
    }
}