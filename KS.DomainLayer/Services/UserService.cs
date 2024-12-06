using KS.DomainLayer.Services.Interfaces;
using KS.InfrastructureLayer.Entities;
using KS.InfrastructureLayer.UnitOfWork;

namespace KS.DomainLayer.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync() => await _unitOfWork.Users.GetAllAsync();

    public async Task<User?> GetUserByIdAsync(int id) => await _unitOfWork.Users.GetByIdAsync(id);

    public async Task AddUserAsync(User user)
    {
        await _unitOfWork.Users.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        await _unitOfWork.Users.UpdateAsync(user);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        if (user != null)
        {
            await _unitOfWork.Users.DeleteAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }

}
