using AutoMapper;
using Demo.AppServices.Abstracts;
using Demo.Domains.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;
using Profile = Demo.Domains.Aggregators.Profile;

namespace Demo.AppServices.Models.Profiles
{
    [AutoMap(typeof(Profile), ReverseMap = true)]
    public class ProfileModel : ModelBase
    {
        #region Properties

        [Required] public string Email { get; set; }

        [StringLength(100)] [Required] public string Firstname { get; set; }

        [StringLength(100)] [Required] public string LastName { get; set; }

        [Phone] public string Phone { get; set; }

        [StringLength(10)] [Required] public string Title { get; set; }

        internal Guid AdAccountId { get; set; }

        internal string MembershipNo { get; set; }

        //[BindNever]
        internal PersonName Name => new PersonName(Title, Firstname, LastName);

        #endregion Properties
    }
}
