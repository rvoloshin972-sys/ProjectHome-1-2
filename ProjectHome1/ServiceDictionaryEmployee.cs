using System;
using System.Collections.Generic;
using static System.Console;

namespace ProjectHome1.services
{
    public class ServiceDictionaryEmployee
    {
        public Dictionary<string, string> Employees { get; set; }
            = new Dictionary<string, string>();
        public ServiceDictionaryEmployee(Dictionary<string, string> employees) 
        {
            Employees = employees;
        }
        public string AddEmployee(string login, string password)
        {
            if (Employees.ContainsKey(login))
            {
                return "Помилка! Такий логін вже існує.";
            }
            Employees.Add(login, password);
            return "Співробітника успішно додано!";
        }
        public string RemoveEmployee(string login)
        {
            if (!Employees.ContainsKey(login))
            {
                return "Помилка! Логін не знайдено.";
            }
            Employees.Remove(login);
            return "Співробітника успішно видалено!";
        }
        public string EditEmployee(string oldLogin, string newLogin, string newPassword)
        {
            if (!Employees.ContainsKey(oldLogin))
            {
                return "Помилка! Старий логін не знайдено.";
            }
            if (oldLogin != newLogin && Employees.ContainsKey(newLogin))
            {
                return "Помилка! Новий логін вже існує.";
            }
            Employees.Remove(oldLogin);
            Employees.Add(newLogin, newPassword);
            return "Інформацію про співробітника змінено!";
        }
        public string GetPassword(string login)
        {
            if (!Employees.ContainsKey(login))
            {
                return "Помилка! Логін не знайдено.";
            }
            return $"Пароль співробітника: {Employees[login]}";
        }
        public void ShowList()
        {
            if (Employees.Count == 0)
            {
                WriteLine("Список співробітників порожній.");
                return;
            }
            int i = 0;
            foreach (var employee in Employees)
            {
                WriteLine($"{++i}. Логін: {employee.Key} | Пароль: {employee.Value}");
            }
        }
    }
}
