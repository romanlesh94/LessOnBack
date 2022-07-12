using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class GetLessonDTO : BaseEntity
    {
        public long UnitId { get; set; }
        public Unit Unit { get; set; }
        public List<CardsetDTO> Cardsets { get; set; }
    }
}
