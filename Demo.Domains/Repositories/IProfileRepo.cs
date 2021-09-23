using Demo.Domains.Aggregators;
using HBD.EfCore.Repos;

namespace Demo.Domains.Repositories
{
    public interface IProfileRepo : IRepository<Profile>
    {
    }
}
