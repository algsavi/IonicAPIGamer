using IonicAPIGamer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IonicAPIGamer.Infra.Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
                .IsUnicode(false)
                .HasMaxLength(50)
                .IsRequired();

        builder.HasMany(u => u.Games);
    }
}
