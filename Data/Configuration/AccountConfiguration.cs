using CelilCavus.RepositoryDesiginPattern.Data.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CelilCavus.RepositoryDesiginPattern.Data.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.AccountNumber).IsRequired();

            builder.Property(x=>x.Balance).HasColumnType("decimal(10,4)");
            builder.Property(x => x.Balance).IsRequired();

        }
    }
}
