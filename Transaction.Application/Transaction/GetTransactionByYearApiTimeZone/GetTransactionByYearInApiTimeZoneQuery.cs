using MediatR;

namespace Transaction.Application.Transaction.GetTransactionByYearApiTimeZone;

public record GetTransactionByYearInApiTimeZoneQuery(int Year) : IRequest<IEnumerable<Models.Transaction.Transaction>>;
