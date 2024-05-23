using Cody.DataAccess.Enitties;
using Cody.DataAccess.Enitties.Commons;
using Cody.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cody.DataAccess.DbContexts;

public class CodyDbContext : DbContext
{
    public CodyDbContext(DbContextOptions<CodyDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        //Database.EnsureCreated();
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
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentGroup> StudentGroups { get; set; }
    public DbSet<HomeTask> Tasks { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Asset> Assets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasOne(student => student.Detail)
            .WithOne()
            .HasForeignKey<Student>(student => student.DetailId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Teacher>()
            .HasOne(teacher => teacher.Detail)
            .WithOne()
            .HasForeignKey<Teacher>(teacher => teacher.DetailId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Parent>()
            .HasOne(Parent => Parent.Detail)
            .WithOne()
            .HasForeignKey<Parent>(parent => parent.DetailId);

        modelBuilder.Entity<Parent>()
            .HasMany(parent => parent.Children)
            .WithOne(child => child.Parent)
            .HasForeignKey(child => child.ParentId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Asset>()
            .HasMany<Student>()
            .WithOne(student => student.Picture)
            .HasForeignKey(student => student.PictureId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Asset>()
            .HasMany<Teacher>()
            .WithOne(teacher => teacher.Picture)
            .HasForeignKey(teacher => teacher.PictureId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Asset>()
            .HasMany<Parent>()
            .WithOne(parent => parent.Picture)
            .HasForeignKey(parent => parent.PictureId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
