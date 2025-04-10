using Microsoft.EntityFrameworkCore;
using receiptAPI.Models;

namespace receiptAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Receipt> Receipts { get; set; }
    }
}
