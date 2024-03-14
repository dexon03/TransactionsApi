using Microsoft.EntityFrameworkCore;

namespace Transaction.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Transaction.Models.Transaction.Transaction> Transactions { get; set; }
}