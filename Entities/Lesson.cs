using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Lesson : BaseEntity
    {
        public long UnitId { get; set; }
        public Unit Unit { get; set; }
        public long Number { get; set; }
        public ICollection<Cardset> Cardsets { get; set; }
    }
}
