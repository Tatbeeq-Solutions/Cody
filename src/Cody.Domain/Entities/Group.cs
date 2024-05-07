using Cody.Domain.Commons;

namespace Cody.Domain.Entities;

public class Group : Auditable
{
    public string Name { get; set; }
    public long CourseId { get; set; }
    public long TeacherId { get; set; }
    public long WeekDayId { get; set; }
    public int MaxEnrollment {  get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set;}

    public Course Course { get; set; }
    public Teacher Teacher { get; set; }
    public GroupWeekDays WeekDay { get; set; }
}