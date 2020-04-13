using System.Threading.Tasks;
using Core.Entities.Identity;

namespace Core.Interfaces
{
    public interface IUserService
    {
        Task<AppUser> RegisterUserAsync(AppUser user);
        Task<AppUser> LoginUserAsync(AppUser user);
        Task<AppUser> ConfirmEmailAsync(string userId, string token);
        Task<AppUser> ForgetPasswordAsync(string email);
        Task<AppUser> ResetPasswordAsync(AppUser user);


    }
}