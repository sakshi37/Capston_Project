using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Domain.Models
{
    public class Book
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public DateTime publishedDate { get; set; }
        [Required]
        public decimal price { get; set; }

        [ForeignKey("author_id")]
        public int authorId { get; set; }
        public virtual Author Author { get; set; }

    }
}
