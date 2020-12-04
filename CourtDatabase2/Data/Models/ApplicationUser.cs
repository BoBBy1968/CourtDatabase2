using Microsoft.AspNetCore.Identity;

namespace CourtDatabase2.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OfficePosition { get; set; }
    }
}
