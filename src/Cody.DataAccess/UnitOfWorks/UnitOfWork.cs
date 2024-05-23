using Cody.DataAccess.DbContexts;
using Cody.DataAccess.Enitties;
using Cody.DataAccess.Enitties.Commons;
using Cody.DataAccess.Repositories;
using Cody.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace Cody.DataAccess.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly CodyDbContext context;
    private IDbContextTransaction transaction;

    public IRepository<Announcement> Announcements { get; }
    public IRepository<Attendance> Attendances { get; }
    public IRepository<Course> Courses { get; }
    public IRepository<Group> Groups { get; }
    public IRepository<GroupWeekDays> GroupWeekDays { get; }
    public IRepository<Lesson> Lessons { get; }
    public IRepository<LessonMark> LessonMarks { get; }
    public IRepository<Notification> Notifications { get; }
    public IRepository<Parent> Parents { get; }
    public IRepository<Student> Students { get; }
    public IRepository<StudentGroup> StudentGroups { get; }
    public IRepository<HomeTask> Tasks { get; }
    public IRepository<Teacher> Teachers { get; }
    public IRepository<User> Users { get; }
    public IRepository<Asset> Assets { get; }

    public UnitOfWork(CodyDbContext context)
    {
        this.context = context;
        Users = new Repository<User>(this.context);
        Assets = new Repository<Asset>(this.context);
        Groups = new Repository<Group>(this.context);
        Tasks = new Repository<HomeTask>(this.context);
        Lessons = new Repository<Lesson>(this.context);
        Parents = new Repository<Parent>(this.context);
        Courses = new Repository<Course>(this.context);
        Teachers = new Repository<Teacher>(this.context);
        Students = new Repository<Student>(this.context);
        Attendances = new Repository<Attendance>(this.context);
        LessonMarks = new Repository<LessonMark>(this.context);
        Notifications = new Repository<Notification>(this.context);
        StudentGroups = new Repository<StudentGroup>(this.context);
        Announcements = new Repository<Announcement>(this.context);
        GroupWeekDays = new Repository<GroupWeekDays>(this.context);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task<bool> SaveAsync()
    {
        return await this.context.SaveChangesAsync() >= 0;
    }

    public async Task BeginTransactionAsync()
    {
        transaction = await this.context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await transaction.CommitAsync();
    }
}