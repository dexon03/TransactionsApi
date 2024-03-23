namespace Transaction.Application.Dtos;

public record TransactionsQueryResultBase
{
    public string TransactionId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public decimal Amount { get; set; }
    public DateTimeOffset UtcTransactionDate { get; set; }
    public string ClientLocation { get; set; }
    public string TimeZoneId { get; set; }
};