using Demo.Domains.Repositories;
using HBD.EfCore.Repos;
using HBD.EfCore.Repos.Basic;
using Profile = Demo.Domains.Aggregators.Profile;

namespace Demo.Infras.Repos
{
    internal class ProfileRepo : Repository<Profile>, IProfileRepo
    {
        public ProfileRepo(IBasicRepository repository) : base(repository)
        {
        }
    }
}
