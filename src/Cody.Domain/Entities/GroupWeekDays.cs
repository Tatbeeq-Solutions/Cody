using Cody.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cody.Domain.Entities;

public class GroupWeekDays : Auditable
{
    public string Name {  get; set; }
}
