namespace Clean.Application.Security.Permission;

public static class PermissionConstants 
    {
        public const string ClaimType = "Permission";
        
        public static class Courses
        {
            public const string View = "Permissions.Courses.View";
            public const string Manage = "Permissions.Courses.Manage";
            public const string ManageSelf = "Permissions.Courses.ManageSelf";
            public const string ManageAll = "Permissions.Courses.ManageAll";
        }

        public static class Modules
        {
            public const string View = "Permissions.Modules.View";
            public const string Manage = "Permissions.Modules.Manage";
            public const string ManageAll = "Permissions.Modules.ManageAll";
        }

        public static class Lessons
        {
            public const string View = "Permissions.Lessons.View";
            public const string Manage = "Permissions.Lessons.Manage";
            public const string ManageSelf = "Permissions.Lessons.ManageSelf";
            public const string ManageAll = "Permissions.Lessons.ManageAll";

        }

        public static class LessonProgresses
        {
            public const string View = "Permissions.LessonProgresses.View";
            public const string Manage = "Permissions.LessonProgresses.Manage";
            public const string ManageSelf = "Permissions.LessonProgresses.ManageSelf";

        }

        public static class Categories
        {
            public const string View = "Permissions.Categories.View";
            public const string Manage = "Permissions.Categories.Manage";
        }

        public static class Enrollments
        {
            public const string View = "Permissions.Enrollments.View";
            public const string Manage = "Permissions.Enrollments.Manage";
            public const string ManageSelf = "Permissions.Enrollments.ManageSelf";
        }

        public static class Users
        {
            public const string ManageAll = "Permissions.Users.ManageAll";
            public const string ManageStudents = "Permissions.Users.ManageStudents";
            public const string ManageSelf = "Permissions.Users.ManageSelf";
            public const string View = "Permissions.Users.View";
        }
    }