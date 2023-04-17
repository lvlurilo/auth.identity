using Microsoft.AspNetCore.Identity;

namespace IdentityAuthentication.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public Guid Code { get; set; }
        public string? FullName { get; set; }
        public int OrgId{ get; set; }
        public List<UserRole>? UserRoles { get; set; }


        public void Create(string username, string email)
        {
            this.UserName = username;
            this.Email = email;
        }
    }
}
