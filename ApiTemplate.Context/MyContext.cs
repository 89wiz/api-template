using ApiTemplate.Context.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Infra.Context;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new TaskMap());
    }
}

/* Commands:
 * Add Migration: dotnet ef migrations add <migration_name> --project ApiTemplate.Context --startup-project ApiTemplate.Api
 * Update Database: dotnet ef database update --project ApiTemplate.Context --startup-project ApiTemplate.Api -- --environment <environment>
 */