using Cody.DataAccess.Enitties.Commons;
using Cody.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cody.Domain.Entities;

public class Task : Auditable
{
    public string Title {  get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public long GroupId {  get; set; }
    public long? FileId { get; set; }

    public Group Group { get; set; }
    public Asset File { get; set; }
}