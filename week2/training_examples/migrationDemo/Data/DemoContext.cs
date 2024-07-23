using Microsoft.EntityFrameworkCore;
using migrationDemo.Models;

public class DemoContext : DbContext
{
    public DemoContext( DbContextOptions<DemoContext> options ) : base( options )
    {

    }

    public DbSet<Departments> departments { get; set; }
    public DbSet<Employees> employees { get; set; }
}