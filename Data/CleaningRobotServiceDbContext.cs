using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class CleaningRobotServiceDbContext(DbContextOptions options) : DbContext(options)
{
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global

    public virtual DbSet<ExecutionLog> Executions { get; set; } = null!;
}