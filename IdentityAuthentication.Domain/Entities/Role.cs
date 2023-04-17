using Microsoft.AspNetCore.Identity;

namespace IdentityAuthentication.Domain.Entities
{
    public class Role : IdentityRole<int>
    {
        public Guid Code { get; set; }
        public List<UserRole>? UserRoles { get; set; }   
    }
}
