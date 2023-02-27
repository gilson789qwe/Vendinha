using Api.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Map;

public class CustomerDebtMap : IEntityTypeConfiguration<CustomerDebtModel>
{
    public void Configure(EntityTypeBuilder<CustomerDebtModel> builder)
    {
        builder.HasKey(x => x.Id);
    }
}