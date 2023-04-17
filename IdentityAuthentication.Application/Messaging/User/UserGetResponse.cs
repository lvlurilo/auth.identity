using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAuthentication.Application.Messaging.User
{
    public class UserGetResponse
    {
        public Guid Code { get; set; }
        public string UserName { get; set; }
    }
}
