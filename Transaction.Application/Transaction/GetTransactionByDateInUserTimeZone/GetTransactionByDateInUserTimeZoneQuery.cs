using MediatR;

namespace Transaction.Application.Transaction.GetTransactionByDateInUserTimeZone;

public record GetTransactionByDateInUserTimeZoneQuery(int? Year, int? Month, DateTimeOffset UserTimeZoneOffset) : IRequest<IEnumerable<Models.Transaction.Transaction>>;