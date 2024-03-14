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
        var query = $"""
                     select * from Transactions
                     where YEAR(TransactionDate) = @Year
                     """;
        var transactions = 
            await connection.QueryAsync<Models.Transaction.Transaction>(query, new { request.Year});
        
        // var currentTimeZone = DateTimeOffset.Now.Offset;
        // foreach (var transaction in transactions)
        // {
        //     var coordinates = transaction.Client_Location;
        //     var latitude = Convert.ToDouble(coordinates.Split(',')[0]);
        //     var longitude = Convert.ToDouble(coordinates.Split(',')[1]);
        //     var timeZone = TimeZoneLookup.GetTimeZone(latitude, longitude).Result;
        //     TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("US Eastern Standard Time");
        //     var test = tzi.BaseUtcOffset;
        // }
        
        return transactions;
    }
}