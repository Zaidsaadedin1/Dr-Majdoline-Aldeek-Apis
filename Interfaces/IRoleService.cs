using Microsoft.AspNetCore.Identity;


namespace Dr_Majdoline_Aldee.Services.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<IdentityRole>> GetAllRolesAsync();
        Task<bool> AssignRoleToUserAsync(string userId, string roleName);
        Task<bool> RemoveRoleFromUserAsync(string userId, string roleName);
        Task<bool> CreateRoleAsync(string roleName);
        Task<bool> DeleteRoleAsync(string roleName);
        Task<IList<string>> GetUserRolesAsync(string userId);
    }
}