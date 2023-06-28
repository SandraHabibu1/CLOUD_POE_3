using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CLOUD_POE_3.Models
{
    [Table("RentalReturn")]
    public partial class RentalReturn
    {
        public RentalReturn() { }   

        [Key]
        [Column("Return_No")]
        [StringLength(6)]
        public string ReturnNo { get; set; }

        [Required]
        [Column("Rental_no")]
        [StringLength(6)]
        public string RentalNo { get; set; }
        [Column(TypeName = "date")]
        public DateTime ReturnDate { get; set; }
        public int ElapsedDate { get; set; }
        
        public int? Fine { get; set; }

    }
    

}
