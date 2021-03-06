using AutoMapper;
using Demo.AppServices.Models.Profiles;
using Demo.Domains.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Profile = Demo.Domains.Aggregators.Profile;

namespace Demo.AppServices.BizActions.Profiles
{
    internal sealed class UpdateProfileAction : BizActionAsync, IUpdateProfileAction
    {
        private readonly IProfileRepo _repo;

        public UpdateProfileAction(IPrincipalProvider principalProvider,
            IMapper mapper,
            IProfileRepo repo)
            : base(principalProvider, mapper) =>
            _repo = repo;

        public async Task<Profile> BizActionAsync(ProfileModel inputData, CancellationToken cancellationToken)
        {
            if (inputData.Id == default)
            {
                AddError("The Id is in valid.", nameof(inputData.Id));
                return null;
            }

            var profile = await _repo.FindAsync(p => p.Id == inputData.Id, cancellationToken);

            if (profile == null)
            {
                AddError($"The Profile {inputData.Id} is not found.", nameof(inputData.Id));
                return null;
            }

            //Update Here
            profile.UpdateName(inputData.Name, inputData.UserId);

            return profile;
        }
    }
}
