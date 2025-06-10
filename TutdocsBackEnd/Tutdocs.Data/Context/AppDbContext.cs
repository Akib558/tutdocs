using Microsoft.EntityFrameworkCore;
using Tutdocs.Data.Configuration;
using Tutdocs.Domain.Entities;

namespace Tutdocs.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}


    #region DbSetCollections

    public DbSet<Users> Users { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsersConfiguration());
        base.OnModelCreating(modelBuilder);
    }
    
    
}