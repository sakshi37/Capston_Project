using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryManagement.Domain.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [Required]
        public decimal PaidAmount { get; set; }
        [Required]
        public DateTime ReturnedAtDate { get; set; }
        [Required]
        public int LoanId { get; set; }
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        [JsonIgnore]
        public virtual Loan Loan { get; set; }



    }
}
