using MediatR;

namespace Transaction.Application.Transaction.GetTransactionDateApiTimeZone;

public record GetTransactionByDateInApiTimeZoneQuery(int? Year, int? Month) : IRequest<IEnumerable<Models.Transaction.Transaction>>;
