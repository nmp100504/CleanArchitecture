using KS.DomainLayer.Services.Interfaces;
using KS.InfrastructureLayer.Entities;
using KS.InfrastructureLayer.UnitOfWork;

namespace KS.DomainLayer.Services;

public class RoleService : IRoleService
{
    private readonly IUnitOfWork _unitOfWork;

    public RoleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Role>> GetAllRolesAsync() => await _unitOfWork.Roles.GetAllAsync();

    public async Task<Role?> GetRoleByIdAsync(int id) => await _unitOfWork.Roles.GetByIdAsync(id);

    public async Task AddRoleAsync(Role role)
    {
        await _unitOfWork.Roles.AddAsync(role);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateRoleAsync(Role role)
    {
        await _unitOfWork.Roles.UpdateAsync(role);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteRoleAsync(int id)
    {
        var role = await _unitOfWork.Roles.GetByIdAsync(id);
        if (role != null)
        {
            await _unitOfWork.Roles.DeleteAsync(role);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public IEnumerable<Role> GetAllRoleWithPaging(int start, int length, string search, out int totalRecords)
    {
        var query = _unitOfWork.Roles.GetAllRoleWithPaging();

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(e => e.RoleName.Contains(search));
        }

        totalRecords = query.Count();

        return query
            .OrderBy(e => e.Id)
            .Skip(start)
            .Take(length)
            .ToList();
    }

}
