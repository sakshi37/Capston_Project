using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Domain.Models
{
    public class Payment
    {
        [Key]
        public int payment_id { get; set; }
        [Required]
        public int paid_amount { get; set; }
        [Required]
        public int returned_at_date { get; set; }


    }
}
