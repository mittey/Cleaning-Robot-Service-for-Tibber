using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class CleaningRobotServiceDbContext : DbContext
{
    protected CleaningRobotServiceDbContext()
    {
    }

    public CleaningRobotServiceDbContext(DbContextOptions options) : base(options)
    {
    }

    // ReSharper disable once PropertyCanBeMadeInitOnly.Globalƒ
    public virtual DbSet<ExecutionLog> Executions { get; set; } = null!;
}