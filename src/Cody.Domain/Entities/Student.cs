using Cody.Domain.Commons;
using Cody.DataAccess.Enitties;
using Cody.DataAccess.Enitties.Commons;

namespace Cody.Domain.Entities;

public class Student : Auditable
{
    public DateTime BirthDay { get; set; }
    public int TotalPoints { get; set; }
    public long UserId { get; set; }
    public long? PictureId { get; set; }
    public long? ParentId { get; set; }


    public User Detail { get; set; }
    public Asset Picture { get; set; }
    public Parent Parent { get; set; }
    public IEnumerable<Group> Groups { get; set; }
    public IEnumerable<LessonMark> LessonMarks { get; set; }
    public IEnumerable<Attendance> Attendances { get; set; }
}