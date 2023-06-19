using Microsoft.EntityFrameworkCore;
using crud_cqrs_pattern_mediatr.Models;

namespace crud_cqrs_pattern_mediatr.Data;

public class AppDbContextWrite : DbContext
{
    public DbSet<Cliente> Clientes { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("crud-cqrs-pattern-write");
    }    
}
