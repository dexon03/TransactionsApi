using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transaction.Models.Transaction;

[Table("transactions")]
public class Transaction
{
    [Key]
    //column name
    [Column("transactionId")]
    public string TransactionId { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [EmailAddress]
    [Column("email")]
    public string Email { get; set; }
    [Column("amount")]
    public decimal Amount { get; set; }
    [Column("transactionDate")]
    public DateTime TransactionDate { get; set; }
    [Column("clientLocation")]
    public string ClientLocation { get; set; }
    [Column("offset")]
    public TimeSpan Offset { get; set; }
}