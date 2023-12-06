using ApiTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiTemplate.Context.Mappings;

internal class TaskMap : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.ToTable("Task")
            .HasKey(x => x.Id);

        builder.HasOne(x => x.User)
            .WithMany(x => x.Tasks)
            .HasPrincipalKey(x => x.Id)
            .HasForeignKey(x => x.UserId);
    }
}
