namespace Transaction.Application.Dtos;

public record TransactionsInApiTimeZoneQueryResult : TransactionsQueryResultBase
{
    public DateTimeOffset TransactionDateInCurrent { get; set; }
}