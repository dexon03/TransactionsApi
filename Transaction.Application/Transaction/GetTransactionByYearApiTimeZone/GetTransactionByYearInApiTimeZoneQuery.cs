using MediatR;

namespace Transaction.Application.Transaction.GetTransactionByYearApiTimeZone;

public record GetTransactionByYearInApiTimeZoneQuery : IRequest<IEnumerable<Models.Transaction.Transaction>>
{
    public int Year { get; set; }
};