using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace Transaction.Models.Transaction;

public class Transaction
{
    [Key]
    public string Transaction_Id { get; set; }
    public string Name { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string Amount { get; set; }
    public DateTimeOffset Transaction_Date { get; set; }
    public string Client_Location { get; set; }
}