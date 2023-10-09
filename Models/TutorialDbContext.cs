using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASP_ENTITY.Models;

public partial class TutorialDbContext : DbContext
{
    public TutorialDbContext()
    {
    }

    public TutorialDbContext(DbContextOptions<TutorialDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=localhost,57000;Database=TutorialDB;User Id=sa;Password=Str#ng_Passw#rd;Trusted_Connection=False;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8C9254C34");

            entity.Property(e => e.CustomerId).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
