using System.ComponentModel.DataAnnotations;

namespace CoreationsTask.Data.Base
{
    public interface IEntityBase
    {
        [Key]
        public int Id { get; set; }

    }
}
    