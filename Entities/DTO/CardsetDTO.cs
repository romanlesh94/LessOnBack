using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class CardsetDTO : BaseEntity
    {
        public string Name { get; set; }
        public long LessonId { get; set; }
        public GetLessonDTO Lesson { get; set; }
        public List<Card> Cards { get; set; }
    }
}
