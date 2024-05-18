using Cody.DataAccess.Enitties;
using Cody.DataAccess.Enitties.Commons;
using Cody.DataAccess.Repositories;
using Cody.Domain.Entities;

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
    IRepository<Student> Students { get; }
    IRepository<StudentGroup> StudentGroups { get; }
    IRepository<HomeTask> Tasks { get; }
    IRepository<Teacher> Teachers { get; }
    IRepository<User> Users { get; }
    IRepository<Asset> Assets { get; }

    Task<bool> SaveAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
}
