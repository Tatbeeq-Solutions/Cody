using Cody.DataAccess.Enitties;
using Cody.DataAccess.Repositories;
using Cody.Domain.Entities;
using Task = Cody.Domain.Entities.Task;

namespace Cody.DataAccess.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{
    IRepository<Announcement> Announcements { get; }
    IRepository<Attendance> Attendances { get; }
    IRepository<Course> Courses { get; }
    IRepository<Group> Groups { get; }
    IRepository<GroupWeekDays> GroupWeekDays { get; }
    IRepository<Lesson> Lessons { get; }
    IRepository<LessonMark> LessonMarks { get; }
    IRepository<Notification> Notifications { get; }
    IRepository<Parent> Parents { get; }
    IRepository<Permission> Permissions { get; }
    IRepository<Role> Roles { get; }
    IRepository<RolePermission> RolePermissions { get; }
    IRepository<Student> Students { get; }
    IRepository<StudentGroup> StudentGroups { get; }
    IRepository<Task> Tasks { get; }
    IRepository<Teacher> Teachers { get; }
    IRepository<User> Users { get; }

    ValueTask<bool> SaveAsync();
    ValueTask BeginTransactionAsync();
    ValueTask CommitTransactionAsync();
}
