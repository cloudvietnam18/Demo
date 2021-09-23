using System.Threading.Tasks;

namespace Demo.Domains.Services
{
    public interface ISequenceServices : IDomainService
    {
        #region Methods

        ValueTask<string> NextValueAsync();

        #endregion Methods
    }
}
