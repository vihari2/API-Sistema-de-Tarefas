using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkSystem.Models;

namespace WorkSystem.Data.Map
{
    public class TaskMap : IEntityTypeConfiguration<TasksModel>
    {
        public void Configure(EntityTypeBuilder<TasksModel> builder)
        {
            builder.HasKey( x => x.Id );
            builder.Property(x => x.Name).IsRequired().HasMaxLength(225);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
