using AutoMapper;
using Demo.Domains.Abstracts;
using HBD.EfCore.BizAction;
using HBD.EfCore.Repos;

// ReSharper disable MemberCanBePrivate.Global

namespace Demo.AppServices.BizActions
{
    internal abstract class BizActionAsync : BizActionStatus
    {
        protected IMapper Mapper { get; }
        protected IPrincipalProvider PrincipalProvider { get; }

        protected BizActionAsync(IPrincipalProvider principalProvider, IMapper mapper)
        {
            PrincipalProvider = principalProvider;
            Mapper = mapper;
        }
    }

    internal abstract class BizActionAsync<TEntity> : BizActionAsync where TEntity : AggregateRoot
    {
        protected IRepository<TEntity> Repository { get; }

        protected BizActionAsync(IPrincipalProvider principalProvider, IMapper mapper, IRepository<TEntity> repository) : base(principalProvider, mapper) => Repository = repository;
    }
}
