using Microsoft.EntityFrameworkCore;
using Rehber.Infrastructure.Models;

namespace Rehber.Infrastructure.Data;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base (options){}
    
    public DbSet<Person> Persons { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<ReportQueu> ReportQueus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasMany(p => p.Contacts);
        
        base.OnModelCreating(modelBuilder);
    }

}