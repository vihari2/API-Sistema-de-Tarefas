using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkSystem.Models;

namespace WorkSystem.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey( x => x.Id );
            builder.Property(x => x.Name).IsRequired().HasMaxLength(225);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
        }
    }
}
