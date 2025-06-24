using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Persistence.Context
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
    

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product() { Id = Guid.NewGuid(), Name = "Pencil", Quantity = 100, Value = 10 },
            new Product() { Id = Guid.NewGuid(), Name = "Paper A4", Quantity = 100, Value = 1 },
            new Product() { Id = Guid.NewGuid(), Name = "Book", Quantity = 500, Value = 25 },
            new Product() { Id = Guid.NewGuid(), Name = "Notebook", Quantity = 200, Value = 15 },
            new Product() { Id = Guid.NewGuid(), Name = "Eraser", Quantity = 300, Value = 3 },
            new Product() { Id = Guid.NewGuid(), Name = "Pen", Quantity = 250, Value = 8 },
            new Product() { Id = Guid.NewGuid(), Name = "Ruler", Quantity = 150, Value = 6 },
            new Product() { Id = Guid.NewGuid(), Name = "Marker", Quantity = 120, Value = 12 }
            );

        base.OnModelCreating(modelBuilder);
    }
  }
}