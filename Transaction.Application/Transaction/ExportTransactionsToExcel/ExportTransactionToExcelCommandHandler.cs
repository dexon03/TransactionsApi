using Dapper;
using MediatR;
using Transaction.Application.Abstractions;

namespace Transaction.Application.Transaction.ExportTransactionsToExcel;

public class ExportTransactionToExcelCommandHandler : IRequestHandler<ExportTransactionToExcelCommand, byte[]>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IExcelService _excelService;

    public ExportTransactionToExcelCommandHandler(ISqlConnectionFactory sqlConnectionFactory, IExcelService excelService)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
        _excelService = excelService;
    }
    public async Task<byte[]> Handle(ExportTransactionToExcelCommand request, CancellationToken cancellationToken)
    {
        await using var connection = _sqlConnectionFactory.CreateConnection();
        var transactions = await connection.QueryAsync<Models.Transaction.Transaction>("SELECT * FROM transactions");
        return _excelService.Export(transactions);
    }
}