using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class LessonDTO : BaseEntity
    {
        public long UnitId { get; set; }
        public virtual GetUnitsDTO Unit { get; set; }
        public long Number { get; set; }
    }
}
