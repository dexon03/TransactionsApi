using MediatR;
using Transaction.Application.Dtos;

namespace Transaction.Application.Transaction.GetTransactionDateApiTimeZone;

public record GetTransactionByDateInApiTimeZoneQuery(int Year, int? Month) : IRequest<IEnumerable<TransactionsInApiTimeZoneQueryResult>>;
