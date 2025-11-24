using System.ComponentModel.DataAnnotations;

namespace Clean.Domain.Enums;

public enum UserRole
{
    [Display(Name = "Student")]
    Student = 1,
    [Display(Name = "Instructor")]
    Instructor = 2,
    [Display(Name = "Admin")]
    Admin = 3
}