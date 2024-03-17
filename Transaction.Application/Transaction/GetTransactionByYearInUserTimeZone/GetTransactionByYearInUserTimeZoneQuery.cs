using MediatR;

namespace Transaction.Application.Transaction.GetTransactionByYearInUserTimeZone;

public record GetTransactionByYearInUserTimeZoneQuery(int Year, DateTimeOffset UserTimeZoneOffset) : IRequest<IEnumerable<Models.Transaction.Transaction>>;