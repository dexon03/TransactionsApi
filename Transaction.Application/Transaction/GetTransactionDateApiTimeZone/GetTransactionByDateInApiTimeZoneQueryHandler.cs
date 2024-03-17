using Dapper;
using MediatR;
using Transaction.Application.Abstractions;

namespace Transaction.Application.Transaction.GetTransactionDateApiTimeZone;

public class GetTransactionByDateInApiTimeZoneQueryHandler : IRequestHandler<GetTransactionByDateInApiTimeZoneQuery, IEnumerable<Models.Transaction.Transaction>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetTransactionByDateInApiTimeZoneQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<IEnumerable<Models.Transaction.Transaction>> Handle(GetTransactionByDateInApiTimeZoneQuery request, CancellationToken cancellationToken)
    {
         await using var connection = _sqlConnectionFactory.CreateConnection();
         var currentTimeZoneOffset = DateTimeOffset.Now.Offset;
         var whereClause = $"\"offset\" = @currentTimeZoneOffset";
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
             await connection.QueryAsync<Models.Transaction.Transaction>(query, new { request.Year, request.Month, currentTimeZoneOffset});
         
        return transactions;
    }
}