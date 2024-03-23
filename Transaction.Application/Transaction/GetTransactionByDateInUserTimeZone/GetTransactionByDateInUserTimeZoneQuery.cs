using MediatR;
using Transaction.Application.Dtos;

namespace Transaction.Application.Transaction.GetTransactionByDateInUserTimeZone;

public record GetTransactionByDateInUserTimeZoneQuery(int Year, int? Month) : IRequest<IEnumerable<TransactionInLocalTimeZoneQueryResult>>;