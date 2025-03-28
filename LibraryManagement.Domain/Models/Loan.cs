using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Domain.Models
{
    internal class Loan
    {
        [Key]
        public int loan_id { get; set; }
        [Required]
        public DateTime start_date { get; set; }
        [Required]
        public DateTime end_date { get; set; }
        [Required]
        public int borrowed_at_price { get; set; }


    }
}
