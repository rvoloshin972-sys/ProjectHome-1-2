using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectHome1.utils
{
    public class EmployeeGen
    {
        private static string[] logins = {"admin","manager","developer","tester","employee"};
        private static string[] passwords = {"Admin123","Manager456","Dev789","Test321","User654"};
        public static Dictionary<string, string> GenEmployees(int n) 
        {
            Dictionary<string, string> employees = new();
            for (int i = 0; i < n; i++) 
            {
                string login = logins[i % logins.Length] + i;
                string password = passwords[i % passwords.Length];
                employees.Add(login, password);
            }
            return employees;
        }
    }
}
