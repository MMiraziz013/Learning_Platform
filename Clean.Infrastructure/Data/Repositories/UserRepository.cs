using Clean.Application.Abstractions;
using Clean.Application.Dtos.User;
using Clean.Domain.Entities;
using Clean.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;
    private readonly UserManager<User> _userManager;

    public UserRepository(DataContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    
    public async Task<User?> GetByIdAsync(int id)
    {
        var user = await _context.Users
            .Include(u => u.Courses)
            .Include(u => u.Enrollments)
            .Include(u => u.LessonProgresses)
            .FirstOrDefaultAsync();
        
        return user;
    }

    public async Task<User?> UpdateAsync(User user)
    {
        await _userManager.UpdateNormalizedEmailAsync(user);
        await _userManager.UpdateNormalizedUserNameAsync(user);
        _context.Update(user);
        var isUpdated = await _context.SaveChangesAsync();
        return isUpdated > 0 ? user : null;
    }

    public async Task<List<User>> GetUsersAsync(string? search = null)
    {
        var query = _userManager.Users
            .Include(u=> u.Courses)
            .Include(u=> u.Enrollments)
            .Include(u=> u.LessonProgresses)
            .AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(u =>
                EF.Functions.ILike(u.UserName!, $"%{search}%") ||
                EF.Functions.ILike(u.Email!, $"%{search}%") ||
                EF.Functions.ILike(u.PhoneNumber!, $"%{search}%"));
        }

        return await query.OrderBy(u => u.Id).ToListAsync();
    }
}