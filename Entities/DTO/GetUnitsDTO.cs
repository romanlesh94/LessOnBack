using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class GetUnitsDTO: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public virtual ICollection<LessonDTO> Lessons { get; set; }
    }
}
