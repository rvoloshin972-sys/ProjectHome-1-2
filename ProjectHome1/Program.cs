using ProjectHome1.models;
using ProjectHome1.services;
using ProjectHome1.utils;
using System.Text;
using static System.Console;

namespace ProjectHome1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Dictionary<string, string> employees = EmployeeGen.GenEmployees(5);
            ServiceDictionaryEmployee serviceDictionary = new(employees);

            int choice = 0;
            string menu = """
                   МЕНЕДЖМЕНТ СПІВРОБІТНИКІВ
                0. Вихід
                1. Додати співробітника
                2. Видалити співробітника
                3. Змінити логін і пароль
                4. Отримати пароль за логіном
                5. Показати всіх співробітників
                Оберіть операцію:
                """;
            do
            {
                Clear();
                WriteLine(menu);
                int.TryParse(ReadLine(), out choice);
                if (choice == 0)
                {
                    break;
                }
                switch (choice)
                {
                    case 1:
                    {
                    Write("Введіть логін: ");
                    string login = ReadLine() ?? "";
                    Write("Введіть пароль: ");
                    string password = ReadLine() ?? "";
                    WriteLine(serviceDictionary.AddEmployee(login, password));
                    break;
                    }

                    case 2:
                    {
                    Write("Введіть логін для видалення: ");
                    string login = ReadLine() ?? "";
                    WriteLine(serviceDictionary.RemoveEmployee(login));
                    break;
                    }

                    case 3:
                    {
                    Write("Введіть старий логін: ");
                    string oldLogin = ReadLine() ?? "";
                    Write("Введіть новий логін: ");
                    string newLogin = ReadLine() ?? "";
                    Write("Введіть новий пароль: ");
                    string newPassword = ReadLine() ?? "";
                    WriteLine(serviceDictionary.EditEmployee(oldLogin, newLogin, newPassword));
                    break;
                    }

                    case 4:
                    {
                    Write("Введіть логін співробітника: ");
                    string login = ReadLine() ?? "";
                    WriteLine(serviceDictionary.GetPassword(login));
                    break;
                    }

                    case 5:
                    {
                    serviceDictionary.ShowList();
                    break;
                    }
                    default:
                    {
                    WriteLine("Невірний вибір операції!");
                    break;
                    }
                }
                WriteLine("\nНатисніть будь-яку клавішу для продовження...");
                ReadKey();
            } while (true);
            WriteLine("Програму завершено.");
        }
    }
}
