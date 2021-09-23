using HBD.StatusGeneric;
using Microsoft.EntityFrameworkCore;
using System;

namespace Demo.AppServices
{
    public static class SaveChangesExceptionHandler
    {
        #region Methods

        public static IStatusGeneric Handler(Exception exception, DbContext dbContext)
        {
            var status = new StatusGenericHandler();

            if (exception != null)
                status.AddError(
                    $"{exception.Message} {(exception.InnerException != null ? "\n" + exception.InnerException.Message : "")}");

            return status;
        }

        #endregion Methods
    }
}
