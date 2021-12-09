using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IAccountService 
    {
        object LogIn(string username, string password);
    }
}
