using AutoMapper;
using Demo.AppServices.Models.Profiles;
using HBD.EfCore.Repos;
using System.Threading;
using System.Threading.Tasks;
using Profile = Demo.Domains.Aggregators.Profile;


namespace Demo.AppServices.BizActions.Profiles
{
    internal class DeleteProfileAction : BizActionAsync<Profile>, IDeleteProfileAction
    {
        public DeleteProfileAction(IPrincipalProvider principalProvider, IMapper mapper, IRepository<Profile> repository) : base(principalProvider, mapper, repository)
        {
        }

        public async Task<Profile> BizActionAsync(ProfileDeleteModel inputData, CancellationToken cancellationToken = new CancellationToken())
        {
            if (inputData.Id == default)
            {
                AddError("The Id is in valid.", nameof(inputData.Id));
                return null;
            }

            var profile = await Repository.FindAsync(inputData.Id);

            if (profile == null)
            {
                AddError($"The Profile {inputData.Id} is not found.", nameof(inputData.Id));
                return null;
            }

            Repository.Delete(profile);
            //This is non auto save Action so need to call SaveAsync manually
            await Repository.SaveAsync(cancellationToken);

            return profile;
        }
    }
}
