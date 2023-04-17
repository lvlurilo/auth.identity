using IdentityAuthentication.Application.Messaging.User;
using IdentityAuthentication.Domain.Entities;

namespace IdentityAuthentication.Application.ApplicationServices.UserApplicationService
{
    public interface IUserApplicationService
    {
        Task<User> CreateUser(UserPostRequest request);
    }
}
