using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class CleaningRobotServiceDbContext : DbContext
{
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public virtual DbSet<ExecutionLog> Executions { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=cleaning_robot_service_db;Username=admin;Password=root");
    }
}