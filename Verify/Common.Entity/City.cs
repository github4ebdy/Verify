using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Common.Entity
{
    [Table("City", Schema = "Base")]
   
    public class City : BaseEntity
    {

        [Column("District_Id", TypeName = "bigint")]
        [Required]
        public long District_Id { get; set; }
        [ForeignKey("District_Id")]
        [JsonIgnore]
        public virtual District District { get; set; }

        [Column("Code", TypeName = "varchar(20)")]
        [MaxLength(20)]
        [Required]
        public string Code { get; set; }

        [Column("CityName", TypeName = "varchar(300)")]
        [MaxLength(300)]
        [Required]
        public string CityName { get; set; }

        

        [Column("Active", TypeName = "bit")]
        [Required]
        public bool Active { get; set; } = true;

        
        
    }
}
