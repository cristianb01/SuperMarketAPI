using SuperMarketAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketAPI.Domain.Services.Communication
{
    public class UserResponse : BaseResponse
    {
        public User User;
        public UserResponse(bool success, string message, User user): base(success,message)
        {
            this.User = user;
        }

        public UserResponse(string message): this(false, message, null)
        {
        }

        public UserResponse(User user): this(true, string.Empty, user)
        {
        }
    }
}
