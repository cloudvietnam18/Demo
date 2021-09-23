using HBD.AspNetCore.Models;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Demo.Infras.Lite")]

namespace Demo.AppServices
{
    public static class ModelExtensions
    {
        #region Methods

        public static bool IsNew<TModel>(this TModel model) where TModel : IModel
        {
            return model.Id == null;
        }

        #endregion Methods
    }
}
