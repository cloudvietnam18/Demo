using System;

namespace Demo.Domains.Abstracts
{
    public abstract class DomainEntity : EntityBase<Guid>
    {
        /// <inheritdoc />
        protected DomainEntity(Guid id, string createdBy, DateTimeOffset? createdOn = null) : base(id) => SetCreatedBy(createdBy, createdOn);

        /// <inheritdoc />
        protected DomainEntity(Guid id) : base(id)
        {
        }

        /// <inheritdoc />
        protected DomainEntity()
        {
        }
    }
}
