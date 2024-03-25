namespace Transaction.Application.Dtos;

public class GetTransactionInInterval
{
    public DateOnly DateFrom { get; set; }
    public DateOnly DateTo { get; set; }
}