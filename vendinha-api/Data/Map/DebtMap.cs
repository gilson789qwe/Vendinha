using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Map;

public class DebtMap : IEntityTypeConfiguration<DebtModel>
{
    public void Configure(EntityTypeBuilder<DebtModel> builder)
    {
        builder.HasKey(x => x.Id);
    }
}