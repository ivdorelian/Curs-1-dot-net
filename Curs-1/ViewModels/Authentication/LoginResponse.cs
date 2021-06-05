using System;
namespace Curs_1.ViewModels.Authentication
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
