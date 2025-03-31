using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Domain.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int AuthorId { get; set; }



        public virtual Author? Author { get; set; }

        public virtual ICollection<Loan>? Loans { get; set; }
        public virtual ICollection<BookCategory>? BookCategories { get; set; }

    }
}
