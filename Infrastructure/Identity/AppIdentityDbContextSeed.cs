using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Cihan",
                    Email = "cihan@test.com",
                    UserName = "cihan@test.com",
                    Addresses = new List<Address>
                    {
                        new Address{
                            FirstName = "Cihan",
                            LastName = "Çakır",
                            Street = "Çıkmaz Sokak",
                            City = "İstanbul",
                            State= "IST",
                            ZipCode="43222"
                        }
                    }
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}