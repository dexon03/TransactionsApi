using Dapper;
using GeoTimeZone;
using MediatR;
using Transaction.Application.Abstractions;

namespace Transaction.Application.Transaction.GetTransactionByYearInUserTimeZone;

public class GetTransactionByYearInUserTimeZoneQueryHandler : IRequestHandler<GetTransactionByYearInUserTimeZoneQuery, IEnumerable<Models.Transaction.Transaction>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetTransactionByYearInUserTimeZoneQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<IEnumerable<Models.Transaction.Transaction>> Handle(GetTransactionByYearInUserTimeZoneQuery request, CancellationToken cancellationToken)
    {
        await using var connection = _sqlConnectionFactory.CreateConnection();
        // var timeZoneFromDateTimeOffset =  TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(t => t.BaseUtcOffset == request.UserTimeZoneOffset.Offset)?.Id;
        // if(timeZoneFromDateTimeOffset is null ){
        //     throw new Exception("Invalid Timezone");
        // }
        var userTimeZoneOffset = request.UserTimeZoneOffset.Offset;
        var query = $"""
                     select * from transactions
                     where date_part('Year',"transactionDate") = @Year and "offset" = @userTimeZoneOffset
                     """;
        var transactions = 
            await connection.QueryAsync<Models.Transaction.Transaction>(query, new { request.Year, userTimeZoneOffset});
        
        return transactions;
    }
}