using Demo.AppServices.Models.Profiles;
using System;
using System.Threading.Tasks;

namespace Demo.AppServices.QueryServices
{
    public interface IProfileQueryService : IQueryService
    {
        ValueTask<ProfileBasicView> GetBasicViewForUserAsync(Guid userId);

    }
}
