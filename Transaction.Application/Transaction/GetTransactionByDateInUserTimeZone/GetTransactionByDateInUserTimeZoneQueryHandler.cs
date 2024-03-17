using Dapper;
using MediatR;
using Transaction.Application.Abstractions;

namespace Transaction.Application.Transaction.GetTransactionByDateInUserTimeZone;

public class GetTransactionByDateInUserTimeZoneQueryHandler : IRequestHandler<GetTransactionByDateInUserTimeZoneQuery, IEnumerable<Models.Transaction.Transaction>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetTransactionByDateInUserTimeZoneQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<IEnumerable<Models.Transaction.Transaction>> Handle(GetTransactionByDateInUserTimeZoneQuery request, CancellationToken cancellationToken)
    {
        await using var connection = _sqlConnectionFactory.CreateConnection();
        var userTimeZoneOffset = request.UserTimeZoneOffset.Offset;
        var whereClause = $"\"offset\" = @userTimeZoneOffset";
        if (request.Month.HasValue)
        {
            whereClause += $" AND date_part('Month', \"transactionDate\") = @Month";
        };
        if (request.Year.HasValue)
        {
            whereClause += $" AND date_part('Year', \"transactionDate\") = @Year";
        }
        var query = $"""
                     select * from transactions
                     where {whereClause}
                     """;
        var transactions = 
            await connection.QueryAsync<Models.Transaction.Transaction>(query, new { request.Year, request.Month, userTimeZoneOffset});
        
        return transactions;
    }
}