using Demo.AppServices.Models.Profiles;
using Demo.Domains.Aggregators;
using HBD.EfCore.BizAction;

namespace Demo.AppServices.BizActions.Profiles
{
    /// <summary>
    /// This is auto action => no need to call _repo.SaveAsync()
    /// </summary>
    public interface ICreateProfileAction : IGenericActionWriteDbAsync<ProfileModel, Profile>
    {
    }
}
