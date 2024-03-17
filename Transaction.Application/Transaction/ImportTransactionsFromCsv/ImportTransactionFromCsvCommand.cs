using MediatR;

namespace Transaction.Application.Transaction.ImportTransactionsFromCsv;

public record ImportTransactionFromCsvCommand(Stream CsvFile) : IRequest;
