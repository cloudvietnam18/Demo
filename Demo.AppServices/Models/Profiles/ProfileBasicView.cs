using AutoMapper;
using Demo.AppServices.Abstracts;
using Profile = Demo.Domains.Aggregators.Profile;

// ReSharper disable ClassNeverInstantiated.Global

namespace Demo.AppServices.Models.Profiles
{
    [AutoMap(typeof(Profile))]
    public class ProfileBasicView : ViewModelBase
    {
        public string Name { get; set; }
    }
}
