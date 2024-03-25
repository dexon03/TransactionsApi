using MediatR;
using Transaction.Application.Dtos;

namespace Transaction.Application.Transaction.GetTransactionByDateInUserTimeZone;

public record GetTransactionByDateInUserTimeZoneQuery(DateOnly DateFrom, DateOnly DateTo) : IRequest<IEnumerable<TransactionInLocalTimeZoneQueryResult>>;