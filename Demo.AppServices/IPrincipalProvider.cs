using HBD.EfCore.DataAuthorization;
using System;

namespace Demo.AppServices
{
    public interface IPrincipalProvider : IDataKeyProvider
    {
        #region Properties

        /// <summary>
        ///     User Email from Bearer Token
        /// </summary>
        string Email { get; }

        /// <summary>
        ///     The User Id from Bearer Token
        /// </summary>
        Guid ProfileId { get; }

        /// <summary>
        ///     User name from Bearer Token
        /// </summary>
        string UserName { get; }

        #endregion Properties
    }
}
