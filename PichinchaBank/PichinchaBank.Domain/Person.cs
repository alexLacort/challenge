using PichinchaBank.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace PichinchaBank.Domain
{
    public abstract class Person : BaseDomainModel
    {   
        public string Identification { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
