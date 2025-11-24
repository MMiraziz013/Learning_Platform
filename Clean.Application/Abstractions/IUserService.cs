using Clean.Application.Dtos.Responses;
using Clean.Application.Dtos.User;

namespace Clean.Application.Abstractions;

public interface IUserService
{
    Task<Response<object>> LoginUserAsync(LoginDto login);
    public Task<Response<GetUserDto>> AddUserAsync(AddUserDto dto);
    public Task<Response<GetUserDto?>> GetUserByIdAsync(int id);
    public Task<Response<List<GetUserDto>>> GetUsersAsync(string? search = null);
    public Task<Response<GetUserDto?>> UpdateUserAsync(UpdateUserDto dto);
    public Task<Response<bool>> DeactivateUserAsync(int id);

}