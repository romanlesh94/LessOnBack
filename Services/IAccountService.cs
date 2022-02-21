﻿using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IAccountService 
    {
        Task<Response> LogInAsync(string username, string password);
        Task <Person> SignUpAsync(string username, string password);
    }
}
