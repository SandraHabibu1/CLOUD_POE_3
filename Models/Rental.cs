using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CLOUD_POE_3.Models
{
    [Table("Rental")]
    public partial class Rental
    {
        public Rental()
        {
        }

        [Key]
        [Column("Rental_no")]
        [StringLength(6)]
        public string RentalNo { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal RentalFee { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        [Required]
        [StringLength(8)]
        public string CarNo { get; set; }
        [Required]
        [Column("Inspector_no")]
        [StringLength(6)]
        public string InspectorNo { get; set; }
        [Required]
        [Column("Driver_ID")]
        [StringLength(10)]
        public string DriverId { get; set; }

       


    }
}