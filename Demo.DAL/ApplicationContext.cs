using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace Demo.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }

        private IDbContextTransaction transaction;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Invoice>().HasMany(x => x.Lines).WithOne();
        }

        public void BeginTransaction()
        {
            this.transaction = this.Database.BeginTransaction();
        }

        public async Task BeginTransactionAsync()
        {
            this.transaction = await this.Database.BeginTransactionAsync();
        }

        public void Commit()
        {
            try
            {
                this.SaveChanges();

                this.transaction.Commit();
            }
            finally
            {
                this.transaction.Dispose();
            }
        }

        public async Task CommitAsync()
        {
            try
            {
                await this.SaveChangesAsync();

                await this.transaction.CommitAsync();
            }
            finally
            {
                await this.transaction.DisposeAsync();
            }
        }

        public void Rollback()
        {
            this.transaction.Rollback();
            this.transaction.Dispose();
        }

        public async Task RollbackAsync()
        {
            await this.transaction.RollbackAsync();
            await this.transaction.DisposeAsync();
        }
    }
}
