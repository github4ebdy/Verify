using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Common.Entity
{
    [Table("District", Schema = "Base")]
   
    public class District : BaseEntity
    {

        [Column("State_Id", TypeName = "bigint")]
        [Required]
        public long State_Id { get; set; }
        [ForeignKey("State_Id")]
        [JsonIgnore]
        public virtual State State { get; set; }

        [Column("Code", TypeName = "varchar(20)")]
        [MaxLength(20)]
        [Required]
        public string Code { get; set; }

        [Column("DistrictName", TypeName = "varchar(300)")]
        [MaxLength(300)]
        [Required]
        public string DistrictName { get; set; }

        

        [Column("Active", TypeName = "bit")]
        [Required]
        public bool Active { get; set; } = true;
        public virtual ICollection<City>? CityList { get; set; }



    }
}
