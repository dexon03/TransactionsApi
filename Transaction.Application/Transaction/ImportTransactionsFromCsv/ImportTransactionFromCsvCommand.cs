using MediatR;

namespace Transaction.Application.Transaction.ImportTransactionsFromCsv;

public record ImportTransactionFromCsvCommand : IRequest
{
    public Stream CsvFile { get; set; }
};