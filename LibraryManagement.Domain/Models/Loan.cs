using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Domain.Models
{
    public class Loan
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int BorrowedAtPrice { get; set; }
        [Required]
        public bool IsReturn { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public string UserId { get; set; }


        public virtual ApplicationUser User { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Book Book { get; set; }



    }
}
