using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CLOUD_POE_3.Models
{
    [Table("Inspector")]
    public partial class Inspector
    {
        public Inspector()
        {
            
        }

        [Key]
        [Column("Inspector_no")]
        [StringLength(6)]
        public string InspectorNo { get; set; }
        [Required]
        [StringLength(50)]
        public string InspectorName { get; set; }
        [Required]
        [StringLength(50)]
        public string InspectorEmail { get; set; }
        [StringLength(20)]
        public string InspectorMobile { get; set; }

       
    }

}
