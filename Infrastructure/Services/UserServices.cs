using System.Threading.Tasks;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    public class UserServices : IUserService
    {
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public UserServices(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Task<AppUser> ConfirmEmailAsync(string userId, string token)
        {
            throw new System.NotImplementedException();
        }

        public Task<AppUser> ForgetPasswordAsync(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<AppUser> LoginUserAsync(AppUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task<AppUser> RegisterUserAsync(AppUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task<AppUser> ResetPasswordAsync(AppUser user)
        {
            throw new System.NotImplementedException();
        }
    }
}