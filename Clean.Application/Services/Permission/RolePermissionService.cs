using Clean.Application.Security.Permission;

namespace Clean.Application.Services.Permission;

public static class RolePermissionService
{
    private static readonly Dictionary<string, List<string>> RolePermissions = new()
    {
        {
            RoleConstants.Admin, new List<string>
            {
                PermissionConstants.Users.ManageAll,
                PermissionConstants.Users.ManageSelf,
                PermissionConstants.Users.ManageStudents,
                PermissionConstants.Users.View,
                
                PermissionConstants.Categories.View,
                PermissionConstants.Categories.Manage,
                
                PermissionConstants.Courses.View,
                PermissionConstants.Courses.Manage,
                PermissionConstants.Courses.ManageAll,
                
                PermissionConstants.Modules.View,
                PermissionConstants.Modules.Manage,
                PermissionConstants.Modules.ManageAll,
                
                PermissionConstants.Lessons.View,
                PermissionConstants.Lessons.Manage,
                PermissionConstants.Lessons.ManageAll,
                
                PermissionConstants.LessonProgresses.View,
                PermissionConstants.LessonProgresses.Manage,
                
                PermissionConstants.Enrollments.View,
                PermissionConstants.Enrollments.Manage,
            }
        },
        {
            RoleConstants.Instructor, new List<string>
            {
                PermissionConstants.Users.ManageSelf,
                PermissionConstants.Users.ManageStudents,
                PermissionConstants.Users.View,
                
                PermissionConstants.Categories.View,
                PermissionConstants.Categories.Manage,
                
                PermissionConstants.Courses.View,
                PermissionConstants.Courses.Manage,
                
                PermissionConstants.Modules.View,
                PermissionConstants.Modules.Manage,
                
                PermissionConstants.Lessons.View,
                PermissionConstants.Lessons.Manage,
                
                PermissionConstants.LessonProgresses.View,
                PermissionConstants.LessonProgresses.Manage,
                
                PermissionConstants.Enrollments.View,
                PermissionConstants.Enrollments.Manage,
            }
        },
        {
            RoleConstants.Student, new List<string>
            {
                PermissionConstants.Users.ManageSelf,
                PermissionConstants.Users.View,
                
                PermissionConstants.Categories.View,
                
                PermissionConstants.Courses.View,
                PermissionConstants.Courses.ManageSelf,
                
                PermissionConstants.Modules.View,
                
                PermissionConstants.Lessons.View,
                PermissionConstants.Lessons.ManageSelf,
                
                PermissionConstants.LessonProgresses.View,
                PermissionConstants.LessonProgresses.ManageSelf,
                
                PermissionConstants.Enrollments.View,
                PermissionConstants.Enrollments.ManageSelf,

            }
        }
    };

    public static IEnumerable<string> GetPermissionsByRoles(IEnumerable<string> roles)
    {
        return roles
            .SelectMany(role => RolePermissions.TryGetValue(role, out var permissions)
                ? permissions
                : Enumerable.Empty<string>())
            .Distinct()
            .ToList();
    }
    
    public static IEnumerable<string> GetAllRoles()
    {
        return RolePermissions.Keys;
    }
}
