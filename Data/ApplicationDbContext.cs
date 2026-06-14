using Microsoft.EntityFrameworkCore;
using bolnica_webapi.Models;

namespace bolnica_webapi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Pacijent> Pacijenti { get; set; }

    public DbSet<Odjel> Odjeli { get; set; }
}