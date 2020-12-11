using Microsoft.AspNetCore.Identity;
using MyFlyer.Model.Entities;
using System.Threading.Tasks;
using MyFlyer.Data.Interfaces;
namespace MyFlyer.Service.Repositories
{
    public class UserRoleRepository : IdentityUserRole<int>, IUserRoleRepository
    {
        private readonly RoleManager<AppRole> roleManager;
        private readonly UserManager<AppUser> userManager;
        public UserRoleRepository(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public async Task AddRole(string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                role = new AppRole
                {
                    Name = roleName,
                    NormalizedName = roleName.ToUpper()
                };
                await roleManager.CreateAsync(role);
            }
        }
        public async Task AddRoleUser(string username, string newRole)
        {
            var user = await userManager.FindByNameAsync(username);
            string oldRole = await (user != null ? GetRoleUser(user) : null);
            if (oldRole != newRole)
            {
                await userManager.RemoveFromRoleAsync(user, oldRole);
                await userManager.AddToRoleAsync(user, newRole);
            }
        }
        public async Task AddUser(AppUser user)
        {
            await userManager.CreateAsync(user);
        }
        public async Task<AppUser> Authentication(string username, string password)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user != null)
            {
                if (user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }
        public async Task<string> GetRoleUser(AppUser user)
        {
            var roles = await userManager.GetRolesAsync(user);
            if (roles.Count > 0)
            {
                return roles[0];
            }
            return null;
        }
        public async Task<string> GetRoleUser(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user != null)
            {
                return await GetRoleUser(user);
            }
            return null;
        }
    }
}
