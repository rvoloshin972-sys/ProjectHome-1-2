using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectHome1.models
{
    public record class Employee
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Employee(string login, string password) 
        {
            Login = login;
            Password = password;
        }
    }
}
