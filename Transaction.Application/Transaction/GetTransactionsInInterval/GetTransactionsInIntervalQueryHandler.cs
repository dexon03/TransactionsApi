using Dapper;
using MediatR;
using Transaction.Application.Abstractions;

namespace Transaction.Application.Transaction.GetTransactionsInInterval;

public class GetTransactionsInIntervalQueryHandler : IRequestHandler<GetTransactionsInIntervalQuery, IEnumerable<Models.Transaction.Transaction>>
{
    private readonly ISqlConnectionFactory _factory;

    public GetTransactionsInIntervalQueryHandler(ISqlConnectionFactory factory)
    {
        _factory = factory;
    }
    public async Task<IEnumerable<Models.Transaction.Transaction>> Handle(GetTransactionsInIntervalQuery request, CancellationToken cancellationToken)
    {
        await using var connection = _factory.CreateConnection();
        
        var query = $"""
                     select * from transactions
                     where DATE("utcTransactionDate") between @dateFrom and @dateTo
                     """;
        // Dapper doesnt support DateOnly, so we need to convert it to DateTime
        var dateFrom = request.DateFrom.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);
        var dateTo = request.DateTo.ToDateTime(TimeOnly.MaxValue, DateTimeKind.Utc);
        var transactions = await connection.QueryAsync<Models.Transaction.Transaction>(query, new { dateFrom , dateTo });
        
        return transactions;
    }
}