using Cody.DataAccess.Enitties;
using Cody.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Task = Cody.Domain.Entities.Task;


namespace Cody.DataAccess.DbContexts;

public class CodyDbContext : DbContext
{
    public CodyDbContext(DbContextOptions<CodyDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupWeekDays> GroupWeekDays { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<LessonMark> LessonMarks { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Parent> Parents { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentGroup> StudentGroups { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<User> Users { get; set; }
}
