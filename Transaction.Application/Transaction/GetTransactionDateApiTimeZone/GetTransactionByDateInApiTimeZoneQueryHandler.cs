using Dapper;
using MediatR;
using TimeZoneConverter;
using Transaction.Application.Abstractions;
using Transaction.Application.Dtos;

namespace Transaction.Application.Transaction.GetTransactionDateApiTimeZone;

public class GetTransactionByDateInApiTimeZoneQueryHandler : IRequestHandler<GetTransactionByDateInApiTimeZoneQuery, IEnumerable<TransactionsInApiTimeZoneQueryResult>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetTransactionByDateInApiTimeZoneQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<IEnumerable<TransactionsInApiTimeZoneQueryResult>> Handle(GetTransactionByDateInApiTimeZoneQuery request, CancellationToken cancellationToken)
    {
         await using var connection = _sqlConnectionFactory.CreateConnection();
         var currentTimeZoneId = TZConvert.WindowsToIana(TimeZoneInfo.Local.Id);
         var castUtcToCurrent = $"\"utcTransactionDate\" at time zone '{currentTimeZoneId}'";
         
         var whereClause = $"date_part('Year', {castUtcToCurrent} ) = @Year";
         if (request.Month.HasValue)
         {
             whereClause += $" AND date_part('Month', {castUtcToCurrent}) = @Month";
         };
         var query = $"""
                      select *, {castUtcToCurrent} as transactionDateInCurrent from transactions
                      where {whereClause}
                      """;
         var transactions = 
             await connection.QueryAsync<TransactionsInApiTimeZoneQueryResult>(query, new { request.Year, request.Month, currentTimeZone = currentTimeZoneId});
         
        return transactions;
    }
}