using PichinchaBank.Domain.Constans;
using System.ComponentModel.DataAnnotations;

namespace PichinchaBank.Domain.Common
{
    public abstract class BaseDomainModel
    {
        [Key]
        public int Id { get; set; }
        public StateType State { get; set; } = StateType.Active;
        public DateTime? CreateDate { get; set; }
    }
}
