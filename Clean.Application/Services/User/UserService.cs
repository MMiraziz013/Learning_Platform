using System.Net;
using Clean.Application.Abstractions;
using Clean.Application.Dtos.Course;
using Clean.Application.Dtos.Enrollment;
using Clean.Application.Dtos.Lesson;
using Clean.Application.Dtos.LessonProgress;
using Clean.Application.Dtos.Responses;
using Clean.Application.Dtos.User;
using Clean.Application.Services.JWT;
using Clean.Domain.Entities;
using Clean.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Clean.Application.Services.User;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly UserManager<Domain.Entities.User> _userManager;
    private readonly IJwtTokenService _tokenService;
    private readonly IConfiguration _configuration;
    private readonly ILogger<Domain.Entities.User> _logger;

    public UserService(
        IUserRepository userRepository, 
        UserManager<Domain.Entities.User> userManager,
        IJwtTokenService tokenService,
        IConfiguration configuration,
        ILogger<Domain.Entities.User> logger)
    {
        _userRepository = userRepository;
        _userManager = userManager;
        _tokenService = tokenService;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<Response<object>> LoginUserAsync(LoginDto login)
    {
        try
        {
            var user = await _userManager.FindByNameAsync(login.Username);
            if (user is null)
                return new Response<object>(HttpStatusCode.BadRequest, "No user with this username.");

            if (!await _userManager.CheckPasswordAsync(user, login.Password))
                return new Response<object>(HttpStatusCode.BadRequest, "Incorrect password.");

            var jwtToken = await _tokenService.GenerateJwtToken(user);
            return new Response<object>(HttpStatusCode.OK, "Login Successful", new
            {
                Token = jwtToken,
                ExpiresAt = DateTime.Now.AddMinutes(double.Parse(_configuration["JWT:AccessTokenMinutes"]!)).ToString("g")
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during LoginUserAsync for {Username}", login.Username);
            return new Response<object>(HttpStatusCode.InternalServerError, "Login failed due to an unexpected error.");
        }
    }


    //TODO: By default isActive property should be true for new users
    public Task<Response<GetUserDto>> AddUserAsync(AddUserDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<GetUserDto?>> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user is null)
        {
            return new Response<GetUserDto?>(HttpStatusCode.BadRequest, "No such user in the system");
        }
        
        var userDto = new GetUserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Role = user.Role,
            RegistrationDate = DateOnly.FromDateTime(user.RegistrationDate),
            IsActive = user.IsActive,
            Courses = user.Courses.Select(c => new CourseBasicDto
            {
                Id = c.Id,
                Title = c.Title
            }).ToList(),
            Enrollments = user.Enrollments.Select(e => new EnrollmentBasicDto
            {
                Id = e.Id,
                EnrolledAt = e.EnrolledAt,
                ProgressPercent = e.ProgressPercent
            }).ToList(),
            LessonProgresses = user.LessonProgresses.Select(l=> new LessonProgressBasicDto
            {
                Id = l.Id,
                IsCompleted = l.IsCompleted
            }).ToList()
        };

        return new Response<GetUserDto?>(HttpStatusCode.OK, userDto);
    }

    public Task<Response<List<GetUserDto>>> GetUsersAsync(string? search = null)
    {
        throw new NotImplementedException();
    }

    public Task<Response<GetUserDto?>> UpdateUserAsync(UpdateUserDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Response<bool>> DeactivateUserAsync(int id)
    {
        throw new NotImplementedException();
    }
}