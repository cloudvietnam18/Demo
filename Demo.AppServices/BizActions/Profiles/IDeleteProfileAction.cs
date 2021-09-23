using Demo.AppServices.Models.Profiles;
using Demo.Domains.Aggregators;
using HBD.EfCore.BizAction;

namespace Demo.AppServices.BizActions.Profiles
{
    /// <summary>
    /// This is not auto action => need to call _repo.SaveAsync()
    /// </summary>
    public interface IDeleteProfileAction : IGenericActionAsync<ProfileDeleteModel, Profile>
    {
    }
}
