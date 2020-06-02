using SuperMarketAPI.Domain.Services.Communication;
using SuperMarketAPI.Models;
using SuperMarketAPI.Resources.Save;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketAPI.Domain.Services
{
    public interface IUserService
    {
        Task<UserResponse> GetById(int id);
        Task<IEnumerable<User>> GetAll();

        Task<UserResponse> Authenticate(AuthenticateResource resource);
    }
}
