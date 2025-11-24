using Clean.Application.Dtos.User;
using Clean.Domain.Entities;

namespace Clean.Application.Abstractions;

public interface IUserRepository
{
    public Task<User?> GetByIdAsync(int id);
    public Task<User?> UpdateAsync(User user);
    public Task<List<User>> GetUsersAsync(string? search = null);
    
}