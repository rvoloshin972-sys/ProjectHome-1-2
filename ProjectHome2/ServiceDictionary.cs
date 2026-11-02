using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectHome2
{
    public class ServiceDictionary
    {
        public Dictionary<string, List<string>> DictionaryWords { get; set; }
        public ServiceDictionary(Dictionary<string, List<string>> dictionary) 
        {
            DictionaryWords = dictionary;
        }
        public void AddWord(DictionaryWord word)
        {
            DictionaryWords.TryAdd(word.EnglishWord,word.FrenchTranslations);
        }
        public string RemoveWord(string word)
        {
            return DictionaryWords.Remove(word)
                ? $"Слово {word} видалено!"
                : $"Слово {word} не знайдено!";
        }
        public string AddTranslation(string word, string translation)
        {
            return DictionaryWords
                .Where(x => x.Key == word)
                .Select(x =>
                {
                    x.Value.Add(translation);
                    return $"Переклад {translation} додано!";
                })
                .DefaultIfEmpty($"Слово {word} не знайдено!")
                .First();
        }
        public string RemoveTranslation(string word, string translation)
        {
            return DictionaryWords
                .Where(x => x.Key == word)
                .Select(x => x.Value.Remove(translation)
                    ? $"Переклад {translation} видалено!"
                    : $"Переклад {translation} не знайдено!")
                .DefaultIfEmpty($"Слово {word} не знайдено!")
                .First();
        }
        public string ChangeWord(string oldWord, string newWord)
        {
            return DictionaryWords
                .Where(x => x.Key == oldWord)
                .Select(x => new DictionaryWord(x.Key, x.Value))
                .Select(x =>
                {
                    DictionaryWords.Remove(oldWord);
                    DictionaryWords.TryAdd(newWord, x.FrenchTranslations);
                    return $"Слово {oldWord} змінено на {newWord}!";
                })
                .DefaultIfEmpty($"Слово {oldWord} не знайдено!")
                .First();
        }
        public string ChangeTranslation(string word,string oldTranslation,string newTranslation)
        {
            return DictionaryWords
                .Where(x => x.Key == word)
                .Select(x => x.Value.IndexOf(oldTranslation))
                .Where(index => index >= 0)
                .Select(index =>
                {
                    DictionaryWords[word][index] = newTranslation;
                    return $"Переклад змінено на {newTranslation}!";
                })
                .DefaultIfEmpty($"Слово або переклад не знайдено!")
                .First();
        }
        public void SearchWord(string word)
        {
            var result = DictionaryWords
                .Where(x => x.Key.Equals(word, StringComparison.OrdinalIgnoreCase))
                .Select(x => new DictionaryWord(x.Key, x.Value))
                .FirstOrDefault();
            Console.WriteLine
                (result == null
                ? $"Слово {word} не знайдено!"
                : $"{result.EnglishWord} - {string.Join(", ", result.FrenchTranslations)}"
                );
        }
        public void ShowDictionary()
        {
            DictionaryWords
                .OrderBy(x => x.Key)
                .ToList()
                .ForEach(x =>
            Console.WriteLine($"{x.Key} - {string.Join(", ", x.Value)}"));
        }
    }
}
