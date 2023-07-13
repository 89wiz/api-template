using ApiTemplate.Context.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Infra.Data.Context;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new TaskMap());
    }
}