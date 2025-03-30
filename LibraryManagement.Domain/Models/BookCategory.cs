using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Domain.Models
{
    public class BookCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int BookId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Book Book { get; set; }
    }
}
