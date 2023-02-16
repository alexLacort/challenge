using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PichinchaBank.Domain;
using PichinchaBank.Domain.Common;

namespace PichinchaBank.Infrastructure.Persistence
{
    public class PichinchaBankDbContext : DbContext
    {
        public PichinchaBankDbContext(DbContextOptions<PichinchaBankDbContext> options) : base(options)
        {

        }

        public DbSet<BankingTransaction>? BankTransactions { get; set; }
        public DbSet<Client>? Clients { get; set; }
        public DbSet<Account>? Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasIndex(k => k.Identification).IsUnique();

            modelBuilder.Entity<Account>()
                .HasIndex(k => k.AccountNumber).IsUnique();

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Accounts)
                .WithOne(a => a.Client)
                .HasForeignKey(f => f.ClientId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        item.Entity.CreateDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                    case EntityState.Detached:
                    case EntityState.Unchanged:
                    case EntityState.Deleted:
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
