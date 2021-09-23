using AutoMapper;
using Demo.Domains.Abstracts;
using Demo.Domains.ValueObjects;
using System;
using Profile = Demo.Domains.Aggregators.Profile;

//Add this to allows to define Record with inline read only properties
namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit { }
}

namespace Demo.Domains.Events
{
    [AutoMap(typeof(Profile), ReverseMap = true)]
    public sealed record ProfileCreatedEvent(Guid Id, PersonName Name) : DomainEvent;

}
