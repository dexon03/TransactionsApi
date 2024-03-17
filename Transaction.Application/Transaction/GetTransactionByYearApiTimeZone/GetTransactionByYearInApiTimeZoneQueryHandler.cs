using Dapper;
using GeoTimeZone;
using MediatR;
using Transaction.Application.Abstractions;

namespace Transaction.Application.Transaction.GetTransactionByYearApiTimeZone;

public class GetTransactionByYearInApiTimeZoneQueryHandler : IRequestHandler<GetTransactionByYearInApiTimeZoneQuery, IEnumerable<Models.Transaction.Transaction>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetTransactionByYearInApiTimeZoneQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<IEnumerable<Models.Transaction.Transaction>> Handle(GetTransactionByYearInApiTimeZoneQuery request, CancellationToken cancellationToken)
    {
         await using var connection = _sqlConnectionFactory.CreateConnection();
         var currentTimeZoneOffset = DateTimeOffset.Now.Offset;
         var query = $"""
                      select * from transactions
                      where date_part('Year',"transactionDate") = @Year and "offset" = @currentTimeZoneOffset
                      """;
         var transactions = 
             await connection.QueryAsync<Models.Transaction.Transaction>(query, new { request.Year, currentTimeZoneOffset});
         
        return transactions;
    }
}