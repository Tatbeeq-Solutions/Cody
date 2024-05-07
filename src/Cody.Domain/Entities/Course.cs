using Cody.DataAccess.Enitties.Commons;
using Cody.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cody.Domain.Entities
{
    public class Course : Auditable
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        public int DurationInMonth {  get; set; }
        public string Prerequisites { get; set; }
        public long SyllabusId {  get; set; }
        public Asset Syllabus { get; set; }
    }
}
