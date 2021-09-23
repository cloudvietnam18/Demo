using Demo.Domains;
using Demo.Domains.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Demo.Infras.Services
{
    internal abstract class SequenceService : DomainService, ISequenceServices
    {
        protected SequenceService(DbContext dbContext, Sequences sequence)
        {
            _dbContext = dbContext;
            _sequence = sequence;
        }

        public virtual ValueTask<string> NextValueAsync() => _dbContext.NextSeqValueWithFormat(_sequence);


        private readonly DbContext _dbContext;
        private readonly Sequences _sequence;
    }
}
