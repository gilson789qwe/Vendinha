using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Map;

public class UserMap : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
        builder.Property(x => x.CPF).IsRequired().HasMaxLength(11);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
    }
}