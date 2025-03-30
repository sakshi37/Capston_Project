using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Domain.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [Required]
        public int PaidAmount { get; set; }
        [Required]
        public int ReturnedAtDate { get; set; }
        [Required]
        public int LoanId { get; set; }
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Loan Loan { get; set; }



    }
}
