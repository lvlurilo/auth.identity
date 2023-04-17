using IdentityAuthentication.Application.Messaging.User;
using IdentityAuthentication.Domain.Entities;
using IdentityAuthentication.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace IdentityAuthentication.Application.ApplicationServices.UserApplicationService
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly UserManager<User> _userManager;

        public UserApplicationService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> CreateUser(UserPostRequest request)
        {
            var anyUser = await _userManager.FindByNameAsync(request.UserName);

            ExceptionBase.When(anyUser != null, "Usuário já existe.");

            var user = new User();

            user.Create(request.UserName, request.Email);

            var result = await _userManager.CreateAsync(user, request.Password);

            ExceptionBase.When(!result.Succeeded, "Não foi possível criar um novo usúario.");

            var token = CreateToken();

            SendEmailConfirmCreateUser(token, user.Email);
            
            return user;
        }

        public async void SendEmailConfirmCreateUser(string token, string email)
        {
        }

        public string CreateToken()
        {
            return "";
        }
    }

}
