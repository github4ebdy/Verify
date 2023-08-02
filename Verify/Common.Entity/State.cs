using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Common.Entity
{
    [Table("State", Schema = "Base")]
   
    public class State : BaseEntity
    {
        [Column("Country_Id", TypeName = "bigint")]
        [Required]
        public long Country_Id { get; set; }

        [ForeignKey("Country_Id")]
        [JsonIgnore]
        public virtual Country Country { get; set; }

        [Column("Code", TypeName = "varchar(20)")]
        [MaxLength(20)]
        [Required]
        public string Code { get; set; }

        [Column("StateName", TypeName = "varchar(300)")]
        [MaxLength(300)]
        [Required]
        public string StateName { get; set; }

        

        [Column("Active", TypeName = "bit")]
        [Required]
        public bool Active { get; set; } = true;

        
        public virtual ICollection<District>? DistrictList { get; set; }

    }
}
