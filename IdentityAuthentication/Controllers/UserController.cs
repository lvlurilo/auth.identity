using IdentityAuthentication.Application.ApplicationServices.UserApplicationService;
using IdentityAuthentication.Application.Messaging.User;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAuthentication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserApplicationService _userApplicationService;

        public UserController(IUserApplicationService userApplicationService)
        {
            _userApplicationService = userApplicationService;
        }

        [HttpGet]
        public ActionResult<UserPostRequest> GetAllUsers()
        {
            try
            {
                var user = new UserPostRequest();

                if(user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro: " + ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<UserGetResponse> GetUserById(Guid id)
        {
            try
            {
                var user = "1";

                if (user == null)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro: " + ex);
            }
        }

        [HttpPost]
        public ActionResult<UserPostResponse> CreateUser(UserPostRequest request)
        {
            try
            {
                var user = _userApplicationService.CreateUser(request);

                return Created(nameof(CreateUser), user);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro: " + ex);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser()
        {
            try
            {
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro: " + ex);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser()
        {
            try
            {
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro: " + ex);
            }
        }
    }
}
