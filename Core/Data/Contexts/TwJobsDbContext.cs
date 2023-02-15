using Microsoft.EntityFrameworkCore;
using TWJOBS.Core.Data.EntityConfigs;
using TWJOBS.Core.Models;

namespace TWJOBS.Core.Data.Contexts;


public class TwJobsDbContext: DbContext{
    public DbSet<Job> Jobs => Set<Job>();
    protected override void OnConfiguring(DbContextOptionsBuilder builder){
        builder.UseSqlServer("Server=Localhost;Database=TWJobs;Trusted_Connection=True;TrustServerCertificate=True;");
    }
    protected override void OnModelCreating(ModelBuilder builder)    {
        builder.ApplyConfiguration(new JobEntityConfig());
    }
 }  