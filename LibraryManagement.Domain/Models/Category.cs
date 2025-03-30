using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Domain.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<BookCategory> BookCategories { get; set; }
    }
}
