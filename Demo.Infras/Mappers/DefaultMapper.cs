
using HBD.EfCore.Extensions.Configurations;

namespace Demo.Infras.Mappers
{
    internal class DefaultMapper<T> : EntityTypeConfiguration<T> where T : class
    {
        //public override void Configure(EntityTypeBuilder<T> builder)
        //{
        //    base.Configure(builder);
        //}
    }
}
