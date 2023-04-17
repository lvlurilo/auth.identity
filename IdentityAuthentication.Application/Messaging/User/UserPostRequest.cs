using System.ComponentModel.DataAnnotations;

namespace IdentityAuthentication.Application.Messaging.User
{
    public class UserPostRequest
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
