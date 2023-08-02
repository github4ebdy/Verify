using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace Common.Entity
{
    public class BaseEntity : IEntity
    {
        [Key]
        [Column("Id", TypeName = "bigint")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("IsDeleted", TypeName = "bit")]
        [Required]
        public bool IsDeleted { get; set; } = false;




    }
}