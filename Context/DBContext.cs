using ElectricalAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace ElectricalAPI.Context
{
    public class DBContext : DbContext
    {
        public DbSet<EFProject> Projects { get; set; }
        public DbSet<EFClient> Clients { get; set; }
        public DbSet<EFWorker> Workers { get; set; }
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
