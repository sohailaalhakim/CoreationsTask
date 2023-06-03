using System.ComponentModel.DataAnnotations;

namespace CoreationsTask
{
    public interface IEntityBase
    {
        [Key]
        public int Id { get; set; }

    }
}
    