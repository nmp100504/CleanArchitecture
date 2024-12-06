using KS.InfrastructureLayer.Entities;

namespace KS.DomainLayer.Services.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<Role>> GetAllRolesAsync();
    Task<Role?> GetRoleByIdAsync(int id);
    Task AddRoleAsync(Role role);
    Task UpdateRoleAsync(Role role);
    Task DeleteRoleAsync(int id);
    IEnumerable<Role> GetAllRoleWithPaging(int start, int length, string search, out int totalRecords);

}
