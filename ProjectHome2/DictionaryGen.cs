using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectHome2
{
    public static class DictionaryGen
    {
        public static Dictionary<string, List<string>> GenDictionary() 
        {
            Dictionary<string, List<string>> dictionary = new()
            {
                { "Hello", new List<string> { "Bonjour", "Salut" } },
                { "Goodbye", new List<string> { "Au revoir", "Adieu" } },
                { "House", new List<string> { "Maison" } },
                { "Cat", new List<string> { "Chat" } },
                { "Dog", new List<string> { "Chien" } },
                { "Book", new List<string> { "Livre" } },
                { "Water", new List<string> { "Eau" } },
                { "Friend", new List<string> { "Ami", "Amie" } },
                { "Love", new List<string> { "Amour" } },
                { "School", new List<string> { "École" } }
            };
            return dictionary;
        }
    }
}
