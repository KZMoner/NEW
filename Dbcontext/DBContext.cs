using Microsoft.EntityFrameworkCore;
using New.Models;

public class APPDBcontext : DbContext
{
    public APPDBcontext(DbContextOptions<APPDBcontext> options) : base(options)
    {
    } // ✅ Added missing closing brace

    public DbSet<rotien> Rotiens { get; set; }
    public DbSet<Registration> Registrations { get; set; }
    public DbSet<RotienLog> RotienLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<rotien>().ToTable("rotien");
        modelBuilder.Entity<Registration>().ToTable("Registration");
        modelBuilder.Entity<RotienLog>().ToTable("RotienLog");
      

    }

}