using Dresses.Core.Entities;

using Microsoft.EntityFrameworkCore;


namespace Dresses.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Dress> Dresses { get; set; }
        public DbSet<Rentals> Rentals { get; set; }
        public DbSet<Business> Business { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=rent");
        }
       
    }
}
 