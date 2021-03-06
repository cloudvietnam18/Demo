using Demo.Domains.Aggregators;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Infras.Mappers
{
    internal sealed class ProfileMapper : DefaultMapper<Profile>
    {
        #region Methods

        public override void Configure(EntityTypeBuilder<Profile> builder)
        {
            base.Configure(builder);

            builder.HasIndex(p => p.Email).IsUnique();
            builder.HasIndex(p => p.AdAccountId).IsUnique();
            builder.HasIndex(p => p.MembershipNo).IsUnique();
        }

        #endregion Methods
    }
}
