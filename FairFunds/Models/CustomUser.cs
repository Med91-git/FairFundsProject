using Microsoft.AspNetCore.Identity;

namespace FairFunds.Models
{
    public class CustomUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[]? ProfilePicture
        {
            get; set;

        }
    }
}