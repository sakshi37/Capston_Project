using Microsoft.AspNetCore.Identity;

namespace LibraryManagement.Identity.Model
{
    internal class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
    }
}
