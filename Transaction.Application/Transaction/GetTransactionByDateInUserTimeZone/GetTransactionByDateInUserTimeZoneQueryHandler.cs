using Dapper;
using GeoTimeZone;
using MediatR;
using Transaction.Application.Abstractions;
using Transaction.Application.Dtos;

namespace Transaction.Application.Transaction.GetTransactionByDateInUserTimeZone;

public class GetTransactionByDateInUserTimeZoneQueryHandler : IRequestHandler<GetTransactionByDateInUserTimeZoneQuery, IEnumerable<TransactionInLocalTimeZoneQueryResult>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetTransactionByDateInUserTimeZoneQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<IEnumerable<TransactionInLocalTimeZoneQueryResult>> Handle(GetTransactionByDateInUserTimeZoneQuery request, CancellationToken cancellationToken)
    {
        await using var connection = _sqlConnectionFactory.CreateConnection();
        
        var castUtcToLocal = $"\"utcTransactionDate\" at time zone t.\"timeZoneId\"";
        var whereClause = $"DATE({castUtcToLocal}) between @dateFrom and @dateTo";
        // if (request.Month.HasValue)
        // {
        //     whereClause += $" AND date_part('Month', {castUtcToLocal}) = @Month";
        // }
        var query = $"""
                     select *, {castUtcToLocal} as localTransactionDate from transactions
                     where {whereClause}
                     """;
        
        var dateFrom = request.DateFrom.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);
        var dateTo = request.DateTo.ToDateTime(TimeOnly.MaxValue, DateTimeKind.Utc);
        var transactions = 
            await connection.QueryAsync<TransactionInLocalTimeZoneQueryResult>(query, new { dateFrom, dateTo});
        
        return transactions;
    }
}