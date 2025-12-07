using Microsoft.EntityFrameworkCore;
using TopOrder.Entitites;

namespace TopOrder.DAL
{
    public class TopOrderContext(DbContextOptions<TopOrderContext> options) : DbContext(options)
    {
        public DbSet<Status> Statuses { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AggregationDbInMemory");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Status>(s =>
            {
                s.HasKey(ds => ds.Id);
                s.HasData(new Status { Id = 1, Code = StatusCode.Processing, Name = "Processing" },
                    new Status { Id = 2, Code = StatusCode.Shipped, Name = "Shipped" },
                    new Status { Id = 3, Code = StatusCode.Canceled, Name = "Canceled" });
            });

            modelBuilder.Entity<Order>(o =>
            {
                o.HasKey(ds => ds.Id);
                o.HasOne(ds => ds.Status)
                 .WithMany()
                 .HasPrincipalKey(s => s.Id);
                o.HasData(new Order{ Amount = 100, CustomerName = "Customer 1", StatusId = 1, Id = 1, Date = DateTime.Now.AddDays(-1) },
                    new Order { Amount = 2000, CustomerName = "Customer 2", StatusId = 2, Id = 2, Date = DateTime.Now.AddDays(-300) },
                    new Order { Amount = 10000, CustomerName = "Customer 2", StatusId = 3, Id = 3, Date = DateTime.Now.AddDays(-30) },
                    new Order { Amount = 40000, CustomerName = "Customer 3", StatusId = 2, Id = 4, Date = DateTime.Now.AddDays(-30) },
                    new Order { Amount = 40000, CustomerName = "Customer 4", StatusId = 2, Id = 5, Date = DateTime.Now.AddDays(-31) },
                    new Order { Amount = 5500, CustomerName = "Customer 5", StatusId = 2, Id = 6, Date = DateTime.Now.AddDays(-100) }
                    );
            });
        }
    }
}
