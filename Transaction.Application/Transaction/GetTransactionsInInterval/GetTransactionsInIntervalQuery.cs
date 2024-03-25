using MediatR;
using Transaction.Application.Dtos;

namespace Transaction.Application.Transaction.GetTransactionsInInterval;

public record GetTransactionsInIntervalQuery(DateOnly DateFrom, DateOnly DateTo) : IRequest<IEnumerable<Models.Transaction.Transaction>>;