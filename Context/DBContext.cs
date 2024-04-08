using BudgetAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace BudgetAPI.Context
{
    public class DBContext : DbContext
    {
        public DbSet<EFCategory> Categories { get; set; }
        public DbSet<EFUser> Users { get; set; }
        public DbSet<EFTransaction> Transactions { get; set; }
        public DbSet<EFBudget> Budgets { get; set; }
        public DBContext(string cnnString)
        {
            ConnectionString = cnnString;
            Database.EnsureCreated();
        }

        public string ConnectionString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
