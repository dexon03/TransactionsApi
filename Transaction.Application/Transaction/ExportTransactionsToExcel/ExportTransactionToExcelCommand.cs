using MediatR;

namespace Transaction.Application.Transaction.ExportTransactionsToExcel;

public record ExportTransactionToExcelCommand() : IRequest<byte[]>;