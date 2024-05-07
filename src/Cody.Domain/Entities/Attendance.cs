using Cody.Domain.Commons;
using Cody.Domain.Enums;

namespace Cody.Domain.Entities;

public class Attendance : Auditable
{
    public long StudentId { get; set; }
    public long LessonId { get; set; }
    public AttendanceStatus Status { get; set; }

    //public Student Student { get; set; }  
    //public Lesson Lesson { get; set; }  
}