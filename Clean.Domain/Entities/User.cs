using Microsoft.AspNetCore.Identity;

namespace Clean.Domain.Entities;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public DateTime RegistrationDate { get; set; }

    //TODO: Add other properties (Role, PhoneNumber, AssignedCourses, 
}