using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObject
{

    public class MyDbContext : DbContext 
    {    
        public MyDbContext(){ }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public virtual DbSet<Category> Category { set; get; }
        public virtual DbSet<Product> Products { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("TrongConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }  
        }

        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            optionsBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "test"}
            );
        }
    }
}