using Cody.DataAccess.DbContexts;
using Cody.DataAccess.Enitties;
using Cody.DataAccess.Repositories;
using Cody.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Task = Cody.Domain.Entities.Task;

namespace Cody.DataAccess.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly CodyDbContext context;

    public IRepository<Announcement> Announcements { get; }
    public IRepository<Attendance> Attendances { get; }
    public IRepository<Course> Courses { get; }
    public IRepository<Group> Groups { get; }
    public IRepository<GroupWeekDays> GroupWeekDays { get; }
    public IRepository<Lesson> Lessons { get; }
    public IRepository<LessonMark> LessonMarks { get; }
    public IRepository<Notification> Notifications { get; }
    public IRepository<Parent> Parents { get; }
    public IRepository<Permission> Permissions { get; }
    public IRepository<Role> Roles { get; }
    public IRepository<RolePermission> RolePermissions { get; }
    public IRepository<Student> Students { get; }
    public IRepository<StudentGroup> StudentGroups { get; }
    public IRepository<Task> Tasks { get; }
    public IRepository<Teacher> Teachers { get; }
    public IRepository<User> Users { get; }

    private IDbContextTransaction transaction;

    public UnitOfWork(CodyDbContext context)
    {
        this.context = context;
        Users = new Repository<User>(this.context);
        Roles = new Repository<Role>(this.context);
        Tasks = new Repository<Task>(this.context);
        Groups = new Repository<Group>(this.context);
        Lessons = new Repository<Lesson>(this.context);
        Parents = new Repository<Parent>(this.context);
        Courses = new Repository<Course>(this.context);
        Teachers = new Repository<Teacher>(this.context);
        Students = new Repository<Student>(this.context);
        Permissions = new Repository<Permission>(this.context);
        Attendances = new Repository<Attendance>(this.context);
        LessonMarks = new Repository<LessonMark>(this.context);
        Notifications = new Repository<Notification>(this.context);
        StudentGroups = new Repository<StudentGroup>(this.context);
        Announcements = new Repository<Announcement>(this.context);
        GroupWeekDays = new Repository<GroupWeekDays>(this.context);
        RolePermissions = new Repository<RolePermission>(this.context);
    }


    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async ValueTask<bool> SaveAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public async ValueTask BeginTransactionAsync()
    {
        transaction = await this.context.Database.BeginTransactionAsync();
    }

    public async ValueTask CommitTransactionAsync()
    {
        await transaction.CommitAsync();
    }
}