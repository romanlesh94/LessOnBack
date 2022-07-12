using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{

    public class Unit : BaseEntity
    {
        [MaxLength(30)]
        [MinLength(2)]
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}
