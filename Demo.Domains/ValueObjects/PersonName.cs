using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

// ReSharper disable MemberCanBePrivate.Global

namespace Demo.Domains.ValueObjects
{
    [Owned]
    public class PersonName
    {


        public PersonName(string title, string firstName, string lastName)
        {
            Title = title;
            Firstname = firstName;
            LastName = lastName;
        }

        internal PersonName()
        {
        }



        [MaxLength(100)] [Required] public string Firstname { get; private set; }

        [MaxLength(100)] [Required] public string LastName { get; private set; }

        [MaxLength(10)] [Required] public string Title { get; private set; }

        public override string ToString() => $"{Title}. {Firstname} {LastName}";
    }
}
