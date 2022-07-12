using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class AddCardDTO
    {
        public long CardsetId { get; set; }
        public string Word { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
