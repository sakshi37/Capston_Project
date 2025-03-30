using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LibraryManagement.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }

    }
}
