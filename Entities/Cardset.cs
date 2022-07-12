using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Cardset : BaseEntity
    {
        public string Name { get; set; }
        public long LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public ICollection<Card> Cards { get; set; }
    }
}
