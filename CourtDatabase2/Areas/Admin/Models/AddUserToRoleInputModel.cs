using System.Collections.Generic;

namespace CourtDatabase2.Areas.Admin.Models
{
    public class AddUserToRoleInputModel
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string RoleId { get; set; }

        public string RoleName { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Users { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Roles { get; set; }

    }
}
