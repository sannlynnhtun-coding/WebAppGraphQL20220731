using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppGraphQL20220731.EFDbContext
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

                var connectionString = configuration.GetConnectionString("AppDb");
                optionsBuilder.UseSqlite(connectionString);
            }
        }

        public DbSet<Tbl_Region> Regions { get; set; }
    }

    [Table("Regions")]
    public class Tbl_Region
    {
        [Key]
        public int RegionId { get; set; }
        public string RegionDescription { get; set; }
    }
}
