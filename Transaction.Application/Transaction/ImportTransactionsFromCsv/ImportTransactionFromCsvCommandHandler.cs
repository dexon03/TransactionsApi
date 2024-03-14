using MediatR;
using Transaction.Application.Abstractions;

namespace Transaction.Application.Transaction.ImportTransactionsFromCsv;

public class ImportTransactionFromCsvCommandHandler : IRequestHandler<ImportTransactionFromCsvCommand>
{
    private readonly ICsvService _csvService;

    public ImportTransactionFromCsvCommandHandler(ICsvService csvService)
    {
        _csvService = csvService;
    }
    public Task Handle(ImportTransactionFromCsvCommand request, CancellationToken cancellationToken)
    {
        var transactions = _csvService.ReadCSV<Models.Transaction.Transaction>(request.CsvFile);
        
        return Task.CompletedTask;
    }
}