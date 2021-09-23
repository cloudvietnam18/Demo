using AutoMapper;
using HBD.AspNetCore.Models;
using System;

namespace Demo.AppServices.Abstracts
{
    public abstract class ModelBase : Model
    {
        #region Properties

        [IgnoreMap]
        public override Guid? Id
        {
            get => base.Id;
            set => base.Id = value;
        }

        public string UserId { get; internal set; }

        #endregion Properties
    }
}
