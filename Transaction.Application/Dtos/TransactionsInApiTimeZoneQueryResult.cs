namespace Transaction.Application.Dtos;

public record TransactionsInApiTimeZoneQueryResult : TransactionsQueryResultBase
{
    public DateTime TransactionDateInCurrent { get; set; }
}