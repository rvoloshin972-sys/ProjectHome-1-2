using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectHome2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ServiceDictionary serviceDictionary = new(DictionaryGen.GenDictionary());

            int choice = 0;
            string menu = """
                АНГЛО-ФРАНЦУЗЬКИЙ СЛОВНИК

                Оберіть операцію:

                0. Вихід
                1. Показати словник
                2. Додати слово і переклади
                3. Видалити слово
                4. Додати варіант перекладу
                5. Видалити варіант перекладу
                6. Змінити англійське слово
                7. Змінити французький переклад
                8. Пошук перекладу
                """;
            do 
            {
                Console.Clear();
                Console.WriteLine(menu);

                int.TryParse(Console.ReadLine(), out choice);
                switch (choice) 
                {
                    case 0:
                    {
                       break;
                    }

                    case 1:
                    {
                       serviceDictionary.ShowDictionary();
                       break;
                    }

                    case 2:
                    {
                       Console.Write("Введіть англійське слово: ");
                       string word = Console.ReadLine() ?? "";

                       Console.Write("Введіть французькі переклади через кому: ");
                       List<string> translations = (Console.ReadLine() ?? "")
                            .Split(',', StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.Trim())
                            .ToList();

                       serviceDictionary.AddWord(new DictionaryWord(word, translations));
                       Console.WriteLine("Слово додано!");
                       break;
                    }

                    case 3:
                    {
                       Console.Write("Введіть слово для видалення: ");
                       string word = Console.ReadLine() ?? "";

                       Console.WriteLine(serviceDictionary.RemoveWord(word));
                       break;
                    }

                    case 4:
                    {
                       Console.Write("Введіть англійське слово: ");
                       string word = Console.ReadLine() ?? "";

                       Console.Write("Введіть французький переклад: ");
                       string translation = Console.ReadLine() ?? "";

                       Console.WriteLine(serviceDictionary.AddTranslation(word, translation));
                       break;
                    }

                    case 5:
                    {
                       Console.Write("Введіть англійське слово: ");
                       string word = Console.ReadLine() ?? "";

                       Console.Write("Введіть переклад для видалення: ");
                       string translation = Console.ReadLine() ?? "";

                       Console.WriteLine(serviceDictionary.RemoveTranslation(word, translation));
                       break;
                    }

                    case 6:
                    {
                       Console.Write("Введіть старе англійське слово: ");
                       string oldWord = Console.ReadLine() ?? "";

                       Console.Write("Введіть нове англійське слово: ");
                       string newWord = Console.ReadLine() ?? "";

                       Console.WriteLine(serviceDictionary.ChangeWord(oldWord, newWord));
                       break;
                    }

                    case 7:
                    {
                       Console.Write("Введіть англійське слово: ");
                       string word = Console.ReadLine() ?? "";

                       Console.Write("Введіть старий переклад: ");
                       string oldTranslation = Console.ReadLine() ?? "";

                       Console.Write("Введіть новий переклад: ");
                       string newTranslation = Console.ReadLine() ?? "";

                       Console.WriteLine(serviceDictionary.ChangeTranslation(word, oldTranslation, newTranslation));
                       break;
                    }

                    case 8:
                    {
                       Console.Write("Введіть англійське слово для пошуку: ");
                       string word = Console.ReadLine() ?? "";
                       serviceDictionary.SearchWord(word);
                       break;
                    }

                    default:
                    {
                       Console.WriteLine("Невірний вибір!");
                       break;
                    }
                }
                Console.ReadKey();
            } while (choice != 0);
        }
    }
}
