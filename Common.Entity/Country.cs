using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entity
{
    [Table("Parent", Schema = "Base")]
   
    public class Country : BaseEntity
    {
        [Column("CountryCode", TypeName = "varchar(20)")]
        [MaxLength(20)]
        [Required]
        public string Code { get; set; }

        [Column("CountryName", TypeName = "varchar(300)")]
        [MaxLength(300)]
        [Required]
        public string CountryName { get; set; }

        

        [Column("Active", TypeName = "bit")]
        [Required]
        public bool Active { get; set; } = true;

        
        public virtual ICollection<State>? StateList { get; set; }

    }
}
