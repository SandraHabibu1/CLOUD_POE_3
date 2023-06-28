using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CLOUD_POE_3.Models
{
    [Table("Driver")]
    public partial class Driver
    {
        public Driver()
        {
            
        }

        [Key]
        [Column("Driver_ID")]
        [StringLength(10)]
        public string DriverId { get; set; }
        [Required]
        [StringLength(50)]
        public string DriverName { get; set; }
        [Required]
        [StringLength(100)]
        public string DriverAddress { get; set; }
        [Required]
        [StringLength(50)]
        public string DriverEmail { get; set; }
        public string? DriverMobile { get; set; }

        
    }

}
