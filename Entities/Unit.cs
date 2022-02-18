using System.ComponentModel.DataAnnotations;

namespace Entities
{

    public class Unit
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
