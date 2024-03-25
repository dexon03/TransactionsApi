using MediatR;
using Transaction.Application.Dtos;

namespace Transaction.Application.Transaction.GetTransactionDateApiTimeZone;

public record GetTransactionByDateInApiTimeZoneQuery(DateOnly DateFrom, DateOnly DateTo) : IRequest<IEnumerable<TransactionsInApiTimeZoneQueryResult>>;
