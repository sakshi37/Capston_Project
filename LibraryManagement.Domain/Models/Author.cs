using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Domain.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AuthorName { get; set; }

        public virtual ICollection<Book>? Books { get; set; }
    }
}
