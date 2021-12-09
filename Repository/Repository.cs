using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Repository
{
    public class Repository: IRepository
    {
        private List<Person> PeopleList = new List<Person>
        {
            new Person {Login="admin@gmail.com", Password="12345", Role = "admin" },
            new Person { Login="qwerty@gmail.com", Password="55555", Role = "user" }
        };

        public List<Person> GetPeople()
        {
            return PeopleList;
        }
    }
}
