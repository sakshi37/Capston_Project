using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Domain.Models
{
    public class Author
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
    }
}
