using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Curs_1.ViewModels.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Curs_1.Services
{
    public interface IAuthManagementService
    {
        Task<ServiceResponse<RegisterResponse, IEnumerable<IdentityError>>> RegisterUser(RegisterRequest registerRequest);
        Task<bool> ConfirmUserRequest(ConfirmUserRequest confirmUserRequest);
        Task<ServiceResponse<LoginResponse, string>> LoginUser(LoginRequest loginRequest);
    }
}
