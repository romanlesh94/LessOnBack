using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Person
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
