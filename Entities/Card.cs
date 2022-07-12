using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Card : BaseEntity
    {
        public long CardsetId { get; set; }
        public Cardset Cardset { get; set; }
        public string Word { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
