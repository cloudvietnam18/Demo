using Demo.Domains;
using Demo.Domains.Services;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infras.Services
{
    internal sealed class MembershipService : SequenceService, IMembershipService
    {
        public MembershipService(DbContext dbContext) : base(dbContext, Sequences.Membership)
        {
        }
    }
}
