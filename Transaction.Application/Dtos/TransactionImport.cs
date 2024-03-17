namespace Transaction.Application.Dtos;

public record TransactionImport
{
    public string transaction_id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string amount { get; set; }
    public DateTime transaction_date { get; set; }
    public string client_location { get; set; }
};