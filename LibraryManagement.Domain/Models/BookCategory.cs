using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Domain.Models
{
    internal class BookCategory
    {
        [Required]
        public int category_id { get; set; }
        [Required]
        public int book_id { get; set; }

        [ForeignKey("book_id")]
        public Book book { get; set; }
    }
}
