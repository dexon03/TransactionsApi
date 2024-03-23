namespace Transaction.Application.Dtos;

public record TransactionInLocalTimeZoneQueryResult : TransactionsQueryResultBase
{
    public DateTime LocalTransactionDate { get; set; }
};